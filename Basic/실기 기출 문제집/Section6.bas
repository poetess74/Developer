10 dim a(5,5)
20 i = 1 
30 j = int(5/2) + 1 
40 nmg = 0
100 for k = 1 to 25
110 a(i,j) = k
120 nmg = k-int(k/5)*5
130 if nmg = 0 then goto 200 : else goto 140
140 i = i - 1
150 j = j + 1
160 if i < 1 then goto 170 : else goto 180
170 i = 5
180 if j > 5 then goto 190 : else goto 200
190 j = 1
200 next k 
210 print a
220 end
