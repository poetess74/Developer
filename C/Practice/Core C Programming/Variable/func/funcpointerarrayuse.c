#include <stdio.h>

void open_file() {
    printf("FILE OPENING ...\n");
}

void save_file() {
    printf("FILE SAVEING ...\n");
}

void option() {
    printf("OPTION LOADING ...\n");
}

void print_file() {
    printf("PRINTING FILE ...\n");
}

typedef void (*PFUNC) (void);

int main() {
    PFUNC pf_array[] = {open_file, save_file, option, print_file};
    const char *menu_str[] = {
        "OPEN FILE", "FILE SAVE", "OPTION", "PRINT", "EXIT",
    };
    enum {OPEN_FILE, CLOSE_FILE, OPTION, PRINT, QUIT};
    int size = sizeof(pf_array) / sizeof(pf_array[0]);

    while (1) {
        int selected = 0;
        for (int i = 0; i < size + 1; i++) {
            printf("%d %s\n", i, menu_str[i]);
        }
        printf("SELECT : ");
        scanf("%d", &selected);
        if (selected == QUIT) {
            break;
        }
        if (selected >= 0 && selected < size) {
            pf_array[selected]();
        } else {
            printf("Command not found\n");
        }
    }
    return 0;
}
