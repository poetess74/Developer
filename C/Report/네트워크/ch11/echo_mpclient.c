#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "data_packet.h"

void read_routine(int sock, char *buf);
void write_routine(int sock, char *buf);

int main(int argc, char *argv[]) {
    int sock;
    pid_t pid;
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
    fputs("Your name: ", stdout);
    scanf("%s", data.name);
    pid = fork();
    if (pid == 0) {
        write_routine(sock, data.msg);
    } else {
        read_routine(sock, data.msg);
    }
    close(sock);
    return 0;
}

void read_routine(int sock, char *buf) {
    while(1) {
        int str_len = read(sock, buf, BUF_SIZE);
        if(str_len == 0) {
            return;
        }
        buf[str_len] = 0;
        printf("Message form server: %s", buf);
    }
}

void write_routine(int sock, char *buf) {
    while(TRUE) {
        fgets(buf, BUF_SIZE, stdin);
        if(!strcmp(buf, "q\n") || !strcmp(buf, "Q\n")) {
            shutdown(sock, SHUT_WR);
            return;
        }
        write(sock, buf, strlen(buf));
    }
}
