#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/udp_header.h"

int main(int argc, char* argv[]) {
    int serv_sd, clnt_sd, read_cnt;
    FILE * fp;
    char buf[BUF_SIZE];
    struct sockaddr_in serv_addr, clnt_addr;
    socklen_t clnt_addr_size;

    if(argc != 2) {
        printf("Usage: %s [port]\n", argv[0]);
        exit(0);
    }
    fp = fopen("file_server.c", "rb");
    serv_sd = socket(PF_INET, SOCK_STREAM, 0);

    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    bind(serv_sd, (struct sockaddr*)&serv_addr, sizeof(serv_addr));
    listen(serv_sd, 5);
    clnt_addr_size = sizeof(clnt_addr);
    clnt_sd = accept(serv_sd, (struct sockaddr*)&clnt_addr, &clnt_addr_size);

    while(TRUE) {
        read_cnt = fread((void*)buf, 1, BUF_SIZE, fp);
        if (read_cnt < BUF_SIZE) {
            write(clnt_sd, buf, read_cnt);
            break;
        }
        write(clnt_sd, buf, BUF_SIZE);
    }
    shutdown(clnt_sd, SHUT_WR);
    read(clnt_sd, buf, BUF_SIZE);
    printf("Message from client: %s\n", buf);
    fclose(fp);
    close(clnt_sd);
    close(serv_sd);
    return 0;
}
