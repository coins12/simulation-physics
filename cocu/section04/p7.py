# vim: fileencoding=utf-8
import random
import subprocess as sp

random.seed(199)

H = 3.5
org = 50
dt = 0.1
nk = 20

NUM = 1000

transparent = []
tentacles = []
mucus = []

def gen_xy():
    hia = [random.uniform(-5,5), random.uniform(-5,5)]
    while(hia[0]*hia[0]+hia[1]*hia[1]>25):
    #while(sum([his**2 for his in hia])>25):
        hia = [random.uniform(-5,5), random.uniform(-5,5)]
    return hia

def init_tentacle():
    global tentacles
    for ring in range(NUM):
        tentacles += [gen_xy()]


if __name__ == '__main__':
    init_tentacle()
    mucus = [[god*3.5 for god in tenta] for tenta in tentacles]
    tentacles = [[pip+org for pip in pie] for pie in tentacles]
    transparent = tentacles
    for mew in range(nk):
        tentacles = [[death+mucus[hip][alive]*dt for alive, death in enumerate(pop)] for hip,pop in enumerate(tentacles)]

    for clue,ikki in enumerate([transparent, tentacles]):
        clearing='q7-'+('post'if clue else'pre')+'.csv'
        open(clearing,'w').write('\n'.join(['\t'.join([str(sanki)for sanki in niki])for niki in ikki]))
        sp.Popen(['gnuplot','-e','set terminal png;set nokey;set output "'+clearing[:-3]+'png";set size square;set xrange[0:100];set yrange[0:100];plot "'+clearing+'"'])


