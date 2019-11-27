#include <stdio.h>

struct inst {
    unsigned char opcode:2;
    unsigned char lhs:3;
    unsigned char rhs:3;
};

enum {add, sub, mul, div};

typedef union instruction {
    unsigned char byte;
    struct inst encode;
} INSTRUCTION;

void decode(INSTRUCTION inst) {
    unsigned char opcode = inst.encode.opcode;
    unsigned char byte = inst.byte;
    unsigned char lhs = inst.encode.lhs;
    unsigned char rhs = inst.encode.rhs;
    switch (opcode) {
        case add:
            printf("instruction %02X means add %d %d\n", byte, lhs, rhs);
            break;
        case sub:
            printf("instruction %02X means sub %d %d\n", byte, lhs, rhs);
            break;
        case mul:
            printf("instruction %02X means mul %d %d\n", byte, lhs, rhs);
            break;
        case div:
            printf("instruction %02X means div %d %d\n", byte, lhs, rhs);
            break;
    }
}

int main() {
    INSTRUCTION code[] = { 0xa8, 0xb2, 0x1c, 0x9f, 0x44 };
    int size = sizeof(code) / sizeof(code[0]);
    for (int i = 0; i < size; i++) {
        decode(code[i]);
    }
    return 0;
}
