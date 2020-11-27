#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "data_packet.h"

void read_routine(int sock, struct s_msg *buf);
void write_routine(int sock, struct s_msg *buf);

int main(int argc, char *argv[]) {
    int sock;
    pid_t pid;
    struct s_msg msg;
    struct sockaddr_in serv_addr;
    if(argc != 3) {
        printf("Usage: %s [ip] [port]\n", argv[0]);
        exit(1);
    }
    sock = socket(PF_INET, SOCK_STREAM, 0);
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = inet_addr(argv[1]);
    serv_addr.sin_port = htons(atoi(argv[2]));

    if(connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("connect() error");
    }
    pid = fork();
    if (pid == 0) {
        write_routine(sock, &msg);
    } else {
        read_routine(sock, &msg);
    }
    close(sock);
    return 0;
}

void read_routine(int sock, struct s_msg *msg) {
    while(1) {
        int len = read(sock, msg, S_MSG_SIZE);
        if(len == 0) {
            return;
        }
        printf("Message form server: %s", msg->msg);
    }
}

void write_routine(int sock, struct s_msg *msg) {
    fprintf(stdout, "Your name: ");
    fgets(msg->name, NAME_SIZE, stdin);
    msg->name[strlen(msg->name) - 1] = '\0'; // remove LF
    while(1) {
        fgets(msg->msg, BUF_SIZE, stdin);
        if(!strcmp(msg->msg, "q\n") || !strcmp(msg->msg, "Q\n")) {
            shutdown(sock, SHUT_WR);
            return;
        }
        write(sock, msg, S_MSG_SIZE);
    }
}
