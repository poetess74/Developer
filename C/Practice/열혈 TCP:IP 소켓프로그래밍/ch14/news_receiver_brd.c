#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/tcp_header.h"

int main(int argc, char *argv[]) {
    int recv_sock, str_len;
    struct sockaddr_in addr;
    char buf[BUF_SIZE];
    if (argc != 2) {
        printf("Usage : %s [port]\n", argv[0]);
        exit(1);
    }

    recv_sock = socket(PF_INET, SOCK_DGRAM, 0);
    memset(&addr, 0, sizeof(addr));
    addr.sin_family = AF_INET;
    addr.sin_addr.s_addr = htonl(INADDR_ANY);
    addr.sin_port = htons(atoi(argv[1]));

    if (bind(recv_sock, (struct sockaddr*)&addr, sizeof(addr)) == -1) {
        error_handling("bind() error");
    }

    while(TRUE) {
        str_len = recvfrom(recv_sock, buf, BUF_SIZE - 1, 0, NULL, 0);
        if (str_len < 0) { break; }
        buf[str_len] = 0;
        fputs(buf, stdout);
    }
    close(recv_sock);
    return 0;
}
