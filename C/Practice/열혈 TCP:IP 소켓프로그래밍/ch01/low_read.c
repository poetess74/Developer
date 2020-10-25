#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <unistd.h>

void error_handling(char* message);

int main(void) {
    int fd;
    char buff[BUFSIZ];
    fd = open("data.txt", O_RDONLY);
    if (fd == -1) 
        error_handling("open() error!");

    printf("file descriptor : %d\n", fd);
    
    if (read(fd, buff, sizeof(buff)) == -1) 
        error_handling("read() error!");
    
    printf("file data : %s", buff);
    close(fd);
    return 0;
}
void error_handling(char* message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}
