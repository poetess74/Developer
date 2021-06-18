10 i = 0
20 j = 0
30 sw = 0
40 i = i + 1
50 j = j - i
60 if sw = 0 then goto 70 : else goto 90 
70 j = j + i
80 sw = 1
90 j = j - i
100 sw = 0
110 if i < 100 then goto 50 : else goto 120
120 print j
130 end
