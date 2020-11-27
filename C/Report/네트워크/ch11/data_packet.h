#ifndef __TCP_HEADER_H__
#define __TCP_HEADER_H__

#include <unistd.h>
#include <signal.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <sys/wait.h>

#define NAME_SIZE 30 
#define BUF_SIZE 100

#define TRUE 1
#define FALSE 0

struct s_msg {
    char name[NAME_SIZE]; // ID name
    char msg[BUF_SIZE];   // BUF_SIZE = 100
};

#define S_MSG_SIZE sizeof(struct s_msg)

void error_handling(char *message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}

#endif
