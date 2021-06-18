10 i = 0
20 j = 1
30 i = i + 1
40 if i mod 2 = 0 then goto 50 : else goto 60
50 j = j * i
60 j = j * i * (-1)
70 if i < 100 then goto 30 : else goto 80
80 print j
90 end
