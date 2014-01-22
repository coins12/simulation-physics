# vim: fileencoding=utf-8
import random

quu = [[0 for x in range(101)]for x in range(101)]
phi = [[0 for x in range(101)]for x in range(101)]
F = [[0 for x in range(101)]for x in range(101)]

gal = []
soc = []

random.seed(199)

def init_gal(n = 500):
    global gal
    global soc
    def gen_ran():
        (x,y)=(random.uniform(-5,5),random.uniform(-5,5))
        while x*x+y*y>25:
            (x,y)=(random.uniform(-5,5),random.uniform(-5,5))
        return [x,y]
    H = 3.5
    for x in range(n):
        foo = gen_ran()
        gal += [[y+50 for y in foo]]
        soc += [[y*H for y in foo]]

def cal_quu():
    global quu
    global gal
    quu = [[0 for x in range(101)]for x in range(101)]
    for x,y in gal:
        quu[int(round(y))][int(round(x))] += 1
def cal_phi():
    global phi
    phi = [[0 for x in range(101)]for x in range(101)]
    for n in range(50):
        for x in range(1,100):
            for y in range(1,100):
                phi[y][x] = float(phi[y-1][x]+phi[y+1][x]+phi[y][x-1]+phi[y][x+1]-1*1*2*quu[y][x])/4

def cal_F():
    global F
    F = [[0 for x in range(101)]for x in range(101)]
    for x in range(0,100):
        for y in range(0,100):
            fdx = -(phi[y][x+1]-phi[y][x])/1
            fdy = -(phi[y+1][x]-phi[y][x])/1
            F[y][x] = [fdx,fdy]

def cal_nextgen():
    M = 1
    dt = 0.1
    for n,s in enumerate(gal):
        Fp = [x*M for x in F[int(round(s[1]))][int(round(s[0]))]]
        for x in range(2):
            soc[n][x] += dt*Fp[x]/M
            gal[n][x] += dt*soc[n][x]

def _wri_csv(name):
    with open(name+'.csv','w') as fp:
        fp.write('\n'.join(['\t'.join([str(x)for x in line])for line in gal]))

def hahahahahahahahahahahhahahahahahahahahaahh():
    cal_quu()
    cal_phi()
    cal_F()
    cal_nextgen()

def main():
    init_gal()
    _wri_csv('nk00')
    for x in range(2):
        for y in range(20):
            hahahahahahahahahahahhahahahahahahahahaahh()
        _wri_csv('nk{0}'.format(x*20+20))
    for name in ["nk{0:02d}".format(y)for y in[x*20 for x in range(3)]]:
        n = 'set terminal png;set nokey;set output "{name}.png";set size square;set xrange[0:100];set yrange[0:100];plot "{name}.csv"'.format(name=name)
        __import__('subprocess').Popen(['gnuplot','-e',n])

if __name__ == '__main__':
    main()
