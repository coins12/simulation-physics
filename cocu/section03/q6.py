import random

random.seed(199)

cnt = 0

table = [[0 for x in range(5)]for x in range(5)]

def count(x,y):
    _x = int(x//1)
    _y = int(y//1)
    if x%1>0.5:
        _x += 1
    if y%1>0.5:
        _y += 1
    table[_x][_y] += 1
    return 0

def gen():
    r=random.random()*5
    while 4<r:
        r=random.random()*5
    return r


if __name__ == '__main__':
    while cnt<200:
        count(gen(),gen())
        cnt += 1
    for y in table:
        tmp = ''
        for x in y:
            tmp += ','if tmp else''
            tmp += str(x).rjust(2)
        print tmp

