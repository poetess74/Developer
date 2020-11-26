#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "data_packet.h"

void read_childproc(int sig);

int main(int argc, char *argv[]) {
    int serv_sock, clnt_sock, fds[2], str_len, state;
    struct sockaddr_in serv_addr, clnt_addr;
    pid_t pid;
    struct sigaction act;
    socklen_t addr_size;
    if (argc != 2) {
        printf("Usage: %s [port]\n", argv[0]);
        exit(1);
    }
    act.sa_handler = read_childproc;
    sigemptyset(&act.sa_mask);
    act.sa_flags = 0;
    state = sigaction(SIGCHLD, &act, 0);
    serv_sock = socket(PF_INET, SOCK_STREAM, 0);
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET; 
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    if(bind(serv_sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("bind() error");
    }
    if(listen(serv_sock, 5) == -1) {
        error_handling("listen() error");
    }

    pipe(fds);
    pid = fork();
    if (pid == 0) {
//        FILE * fp = fopen("echomsg.txt", "wt");
//        int len;
//        for(int i = 0; i < 10; i++) {
//            len = read(fds[0], data.msg, BUF_SIZE);
//            fwrite((void*)data.msg, 1, len, fp);
//        }
//        fclose(fp);
        return 0;
    }

    while (TRUE) {
        addr_size = sizeof(clnt_addr);
        clnt_sock = accept(serv_sock, (struct sockaddr*)&clnt_addr, &addr_size);
        if (clnt_sock == -1) {
            continue;
        } else {
            puts("new client connected...");
        }
        pid = fork();
        if (pid == 0) {
            close(serv_sock);
            while((str_len = read(clnt_sock, data.msg, BUF_SIZE)) != 0) {
                printf("[%s]: %s\n", data.name, data.msg);
                write(clnt_sock, data.msg, str_len);
                write(fds[1], data.name, str_len);
                write(fds[0], data.msg, str_len);
            }
            close(clnt_sock);
            puts("client disconnected...");
            return 0;
        } else {
            close(clnt_sock);
        }
    }
    close(serv_sock);
    return 0;
}

void read_childproc(int sig) {
    pid_t pid;
    int status;
    pid = waitpid(-1, &status, WNOHANG);
    printf("removed proc id: %d\n", pid);
}
