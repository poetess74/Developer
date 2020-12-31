#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/udp_header.h"

int main(int argc, char* argv[]) {
    int sd, read_cnt;
    FILE *fp;
    char buf[BUF_SIZE];
    struct sockaddr_in serv_addr;
    if (argc != 3) {
        printf("Usage: %s [ip] [port]\n", argv[0]);
        exit(1);
    }
    fp = fopen("receive.dat", "wb");
    sd = socket(PF_INET, SOCK_STREAM, 0);
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = inet_addr(argv[1]);
    serv_addr.sin_port = htons(atoi(argv[2]));

    connect(sd, (struct sockaddr*)&serv_addr, sizeof(serv_addr));
    while((read_cnt = read(sd, buf, BUF_SIZE)) != 0) {
        fwrite((void*)buf, 1, read_cnt, fp);
    }
    puts("Received file data");
    write(sd, "Thank you", 10);
    fclose(fp);
    close(sd);
    return 0;
}
