# vim: fileencoding=utf-8

res = [[0,22.5, 36,  0],
       [0,   0,  0,  9],
       [0,   0,  0,4.5],
       [0,   0,  0,  0]]

dx = 1
dy = 1

f = lambda x,y:6*x-3*y
#d2f = lambda x,y: f(x+1,y)+f(x-1,y)+f(x,y-1)+f(x,y+1)-f(x,y)*4
#r = lambda x,y:res[3-y,3-x]
r = lambda x,y:res[3-y][3-x]
d2f = lambda x,y: float(r(x,y-1)+r(x,y+1)+r(x+1,y)+r(x-1,y)-dx*dx*f(x,y))/4

def gig():
    for x in range(1,3):
        for y in range(1,3):
            res[y][x] = d2f(3-x,3-y)

def main():
    for x in range(1000):
        gig()

    print('\n'.join([','.join(["{0:.2f}".format(x).rjust(5)for x in y])for y in res]))


if __name__ == '__main__':
    main()
