#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "data_packet.h"

int main(int argc, char *argv[]) {
    int sock, str_len, size;
    pid_t pid;
    struct s_msg msg;
    socklen_t addr_size;

    struct sockaddr_in serv_addr, from_addr, get_addr;
    
    size = sizeof(get_addr);
    if(argc != 3) {
        printf("Usage : %s [IP] [port]\n", argv[0]);
        exit(1);
    }

    sock = socket(PF_INET, SOCK_DGRAM, 0);
    if(sock == -1) {
        error_handling("socket() error");
    }

    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = inet_addr(argv[1]);
    serv_addr.sin_port = htons(atoi(argv[2]));

    getsockname(sock, (struct sockaddr *)&get_addr, &size);
    printf("client IP : %s, port : %d\n", inet_ntoa(get_addr.sin_addr), ntohs(get_addr.sin_port));

    fprintf(stdout, "Your name: ");
    fgets(msg.name, NAME_SIZE, stdin);
    msg.name[strlen(msg.name) - 1] = '\0'; // remove LF

    pid_t parent_pid = getpid();

    pid = fork();
    if (pid == 0) {
        while(TRUE) {
            fgets(msg.msg, BUF_SIZE, stdin);
            if (!strcmp(msg.msg, "q\n") || !strcmp(msg.msg, "Q\n")) {
                shutdown(sock, SHUT_RDWR);
                break;
            }
            sendto(sock, &msg, S_MSG_SIZE, 0, (struct sockaddr*)&serv_addr, sizeof(serv_addr));
        }
    } else {
        while(TRUE) {
            getsockname(sock, (struct sockaddr *)&get_addr, &size);

            addr_size = sizeof(from_addr);
            str_len = recvfrom(sock, &msg, S_MSG_SIZE, 0, (struct sockaddr*)&from_addr, &addr_size);
            if (str_len == 0) {
                break;
            }
            printf("[%s] %s", msg.name, msg.msg);
        }
    }
    close(sock);
    return 0;
}
