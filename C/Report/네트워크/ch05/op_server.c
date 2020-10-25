#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>

#include "data_packet.h"

#define SYN_COUNT 5

void error_handling(char *message);
int calculate(int, int[], char);

int main(int argc, char *argv[]) {
    int serv_sock, clnt_sock, result, recv_cnt, recv_len;
    struct sockaddr_in serv_addr, clnt_addr;
    socklen_t clnt_addr_sz;

    struct data_packet packet;

    if(argc != 2) {
        printf("Usage : %s [port]\n", argv[0]);
        exit(1);
    }

    serv_sock = socket(PF_INET, SOCK_STREAM, 0);
    if(serv_sock == -1) {
        error_handling("socket() error");
    }

    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    if(bind(serv_sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("bind() error");
    }
    if(listen(serv_sock, SYN_COUNT) == -1) {
        error_handling("listen() error");
    }

    clnt_addr_sz = sizeof(clnt_addr);

    for(int i = 0; i < SYN_COUNT; i++) {
        clnt_sock = accept(serv_sock, (struct sockaddr*)&clnt_addr, &clnt_addr_sz);

        recv_len = 0;
        while(DATA_PACKET_SIZE > recv_len) {
            recv_cnt = read(clnt_sock, (&packet + recv_len), DATA_PACKET_SIZE - recv_len);
            recv_len += recv_cnt;
        }

        result = calculate(packet.op_num, packet.oprand, packet.op_code);

        write(clnt_sock, (char*)&result, sizeof(result));

        close(clnt_sock);
    }

    close(serv_sock);

    return 0;
}

int calculate(int opnum, int opnds[], char oprator) {
    int result = opnds[0];
    switch(oprator) {
        case '+':
            for(int i = 1; i < opnum; i++) {
                result += opnds[i];
            }
            break;
        case '-':
            for(int i = 1; i < opnum; i++) {
                result -= opnds[i];
            }
            break;
        case '*':
            for(int i = 1; i < opnum; i++) {
                result *= opnds[i];
            }
            break;
    }
    return result;
}

void error_handling(char *message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}
