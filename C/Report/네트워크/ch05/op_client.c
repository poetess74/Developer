#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>

#include "data_packet.h"

#define RLT_SIZE 4

void error_handling(char *message);

int main(int argc, char *argv[]) {
    int sock, result;
    struct sockaddr_in serv_addr;

    struct data_packet packet;

    if(argc != 3) {
        printf("Usage: %s [IP] [port]\n", argv[0]);
        exit(1);
    }

    sock = socket(PF_INET, SOCK_STREAM, 0);
    if (sock == -1) {
        error_handling("socket() error");
    }

    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = inet_addr(argv[1]);
    serv_addr.sin_port = htons(atoi(argv[2]));

    if(connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("connect() error");
    } else {
        puts("Connected. ");
    }

    fputs("Operand count: ", stdout);
    scanf("%d", &packet.op_num);

    for(int i = 0; i < packet.op_num; i++) {
        printf("Operand %d: ", i + 1);
        scanf("%d", &packet.oprand[i]);
    }

    fgetc(stdin);
    fputs("Operator: ", stdout);
    scanf("%c", &packet.op_code);

    write(sock, &packet, DATA_PACKET_SIZE);

    read(sock, &result, RLT_SIZE);
    printf("Operation result: %d\n", result);

    close(sock);

    return 0;
}

void error_handling(char *message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}
