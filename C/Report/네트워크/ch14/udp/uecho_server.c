#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "data_packet.h"

#define MAX_CLIENT 30

int main(int argc, char *argv[]) {
    int serv_sock, str_len;
    pid_t pid;
    struct s_msg msg;
    socklen_t clnt_addr_size;

    struct sockaddr_in serv_addr, clnt_addr;
    struct sockaddr_in save_addr[MAX_CLIENT];
    int client_num = 0;

    if (argc != 2) {
        printf("Usage : %s [port]\n", argv[0]);
        exit(1);
    }

    serv_sock = socket(PF_INET, SOCK_DGRAM, 0);
    if (serv_sock == -1) {
        error_handling("UDP socket creation error");
    }
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    if (bind(serv_sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("bind() error");
    }

    pid = fork();
    if (pid == 0) {
        FILE *fp = fopen("chatmsg.txt", "wt");
        char buf[BUF_SIZE + NAME_SIZE + 5];

        while(TRUE) {
            clnt_addr_size = sizeof(clnt_addr);
            str_len = recvfrom(serv_sock, &msg, S_MSG_SIZE, 0, (struct sockaddr*)&clnt_addr, &clnt_addr_size);
            printf("Client IP : %s, Port : %d\n", inet_ntoa(clnt_addr.sin_addr), ntohs(clnt_addr.sin_port));
            printf("client message : [%s] %s\n", msg.name, msg.msg);
            int new_client = TRUE;
            for (int i = 0; i < client_num; i++) {
                if (save_addr[i].sin_addr.s_addr == clnt_addr.sin_addr.s_addr
                        && save_addr[i].sin_port == clnt_addr.sin_port) {
                    new_client = FALSE;
                    break;
                }
            }

            if (new_client) {
                memcpy(&save_addr[client_num++], &clnt_addr, sizeof(struct sockaddr_in));
            }
            for (int i = 0; i < client_num; i++) {
                sendto(serv_sock, &msg, S_MSG_SIZE, 0, (struct sockaddr*)&save_addr[i], clnt_addr_size);
            }

            sprintf(buf, "[%s] %s", msg.name, msg.msg);
            fwrite(buf, 1, strlen(buf), fp);
            fflush(fp);
        }

        fclose(fp);
    } else {
        int sock = socket(PF_INET, SOCK_DGRAM, 0);
        struct sockaddr_in srv_addr;

        memset(&srv_addr, 0, sizeof(srv_addr));
        srv_addr.sin_family = AF_INET;
        srv_addr.sin_addr.s_addr = inet_addr("localhost");
        srv_addr.sin_port = htons(atoi(argv[1]));

        strcpy(msg.name, "SERVER");
        while(TRUE) {
            fgets(msg.msg, BUF_SIZE, stdin);
            sendto(sock, &msg, S_MSG_SIZE, 0, (struct sockaddr*)&serv_addr, sizeof(serv_addr));
        }
    }
    close(serv_sock);
    return 0;
}
