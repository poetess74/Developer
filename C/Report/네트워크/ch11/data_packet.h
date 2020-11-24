#ifndef __DATA_HEADER_H__
#define __DATA_HEADER_H__

#include <unistd.h>
#include <signal.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <sys/wait.h>

#define BUF_SIZE 100

#define TRUE 1
#define FALSE 0

struct s_msg {
    char name[30];
    char msg[BUF_SIZE];
}data;

void error_handling(char *message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}

#endif
