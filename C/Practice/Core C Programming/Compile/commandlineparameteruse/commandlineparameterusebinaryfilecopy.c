#include <stdio.h>
#include <string.h>

int main (int argc, char * argv[]) {
    unsigned char buff[BUFSIZ];
    FILE *fout = NULL;
    FILE *fin = NULL;
    int cnt_read = 0;
    if (argc < 2) {
        printf("usage : ex13_12 in_filename out filename\n");
        return 1;
    }
    fin = fopen(argv[1], "rb");
    if (fin == NULL) {
        goto cleanup;
    }
    fout = fopen(argv[2], "wb");
    if (fout == NULL) {
        goto cleanup;
    }
    while ((cnt_read =fread(buff, 1, sizeof(buff), fin)) > 0) {
        int cnt_written = fwrite(buff, 1, cnt_read, fout);
        if (cnt_written < cnt_read) {
            goto cleanup;
        }
    }
cleanup:
    if (fin == NULL || fout == NULL) {
        printf("No such file\n");
    } else if (ferror(fin) || ferror(fout)) {
        printf("Error IO\n");
    } else {
        printf("Successfuly copyed file\n");
    }
    if (fin) fclose(fin);
    if (fout) fclose(fout);

    return 0;
}
