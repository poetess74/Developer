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
    struct s_msg msg;
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
        FILE * fp = fopen("echomsg.txt", "wt");
        struct s_msg msgbuf;
        char buf[BUF_SIZE + NAME_SIZE + 5];
        for(int i = 0; i < 10; i++) {
            read(fds[0], &msgbuf, S_MSG_SIZE);
            sprintf(buf, "[%s] : %s\n", msgbuf.name, msgbuf.msg);
            fwrite((void*)buf, 1, strlen(buf), fp);
            fflush(fp);
        }
        fclose(fp);
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
            while((str_len = read(clnt_sock, &msg, S_MSG_SIZE)) != 0) {
                write(clnt_sock, &msg, S_MSG_SIZE);
                write(fds[1], &msg, S_MSG_SIZE);
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
