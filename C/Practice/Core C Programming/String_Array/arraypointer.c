#include <stdio.h>
#include <string.h>

int main() {
    const char * str_menu[] = {
        "EXIT", 
        "NEW", 
        "OPEN", 
        "BUILD", 
        "DEBUG", 
    };
    int sz_menu = sizeof(str_menu) / sizeof(str_menu[0]);
    int menu;

    while (1) {
        for (int i = 0; i < sz_menu; i++) {
            printf("%d.%s\n", i, str_menu[i]);
        }
        printf("SELECT : ");
        scanf("%d", &menu);
        if (menu == 0) {
            break;
        } else if (menu > 0 && menu < sz_menu) {
            printf("%s SELECTED. \n", str_menu[menu]);
        } else {
            printf("CMD NOT FOUND\n");
        }
    }

    return 0;
}
