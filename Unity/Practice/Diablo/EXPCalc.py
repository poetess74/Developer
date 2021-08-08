cycle = int(input("multiplier of exp (default: 2) >  "))
levelCap = int(input("level cap (default: 70) >  "))

result = 400;

for i in range (levelCap):
    result = result * cycle

if result == 0:
    print("Failure! 'result' data type is too small. Please redefination it.")
else:
    print("requirement exp value: " + str(result))
