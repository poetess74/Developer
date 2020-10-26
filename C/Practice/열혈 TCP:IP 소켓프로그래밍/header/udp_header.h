#ifndef __UDP_HEADER_H__
#define __UDP_HEADER_H__

#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>

#define BUF_SIZE 30
#define TRUE 1
#define FALSE 0

void error_handling(char *message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}

#endif
