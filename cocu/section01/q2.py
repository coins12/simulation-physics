import random
from math import pi

if __name__ == '__main__':
    r = random
    r.seed(199)

    res=[]

    for n in [100,1000,10000]:
        c=0
        for i in range(n):
            x=r.uniform(-1,1)
            y=r.uniform(-1,1)
            if(x*x+y*y<=1):
                c += 1
        res+=[(c,n,4*float(c)/n)]
    print('|'.join(['num']+[str(x[1]).center(15)for x in res]))
    print('|'.join(['ave']+[str(x[2]).ljust(15)for x in res]))
    print('|'.join([' '*3]+[str(1-float(x[2])/pi).ljust(5) for x in res]))
    
    



