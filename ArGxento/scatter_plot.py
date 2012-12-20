import random

with open("result.txt", "w") as f:
    count = 0
    while count < 200:
        x = random.random() * 2.0 - 1.0
        y = random.random() * 2.0 - 1.0
        if x**2 + y ** 2 <= 1.0:
            f.write("%f %f\n" % (x, y))
            count += 1

