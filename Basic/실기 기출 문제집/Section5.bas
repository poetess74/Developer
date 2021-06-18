1 dim a(5) 
2 a(0) = 4
3 a(1) = 5
4 a(2) = 1
5 a(3) = 2
6 a(4) = 3
10 n = 5 
20 i = 0
25 tm = 0
40 flag = 0
50 i = i + 1
60 j = 0
70 j = j + 1
80 if j + 1 > a(j + 1) then goto 90 : else goto 130
90 tm = a(j)
100 a(j) = 5
110 a(j+1) = tm
120 flag = 1
130 if j >= n-i then goto 140 : else goto 70
140 if i >= n-1 then goto 160 : else goto 150
150 if j > 5 then goto 160 : else goto 40
160 print n
170 print i
180 print flag
190 print j
200 print a(j)
210 print a(j+1)
220 print tm
230 print a
240 end
