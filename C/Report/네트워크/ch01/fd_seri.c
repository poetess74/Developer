#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <unistd.h>
#include <sys/socket.h>

void error_handling(char* message);

int main(void) {
    int fd1, fd2, fd3, fd4;
    fd1 = socket(PF_INET, SOCK_STREAM, 0);
    fd2 = open("test.dat", O_CREAT|O_WRONLY|O_TRUNC);
    fd3 = socket(PF_INET, SOCK_DGRAM, 0);

    printf("file descriptor 1 : %d\n", fd1);
    printf("file descriptor 2 : %d\n", fd2);
    printf("file descriptor 3 : %d\n", fd3);

    close(fd2);
    fd4 = open("test.dat", O_CREAT|O_WRONLY|O_TRUNC);
    printf("file descriptor 4 : %d\n", fd4);
    
    close(fd1); close(fd2);
    close(fd3); close(fd4);
    return 0;
}
void error_handling(char* message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}
