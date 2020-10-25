#ifndef __DATA_PACKET_H__
#define __DATA_PACKET_H__

struct data_packet {
    int op_num;
    char op_code;
    int oprand[30];
};

#define DATA_PACKET_SIZE (sizeof(struct data_packet))

#endif
