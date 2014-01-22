# vim: fileencoding=utf-8
import random

random.seed(199)

def gen_xy():
    x = random.random()
    y = random.random()
    while(x*x+y*y>1):
        x = random.random()
        y = random.random()
    return (x,y)
        


def main():
    pass

if __name__ == '__main__':
    main()
