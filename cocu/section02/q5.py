import random

kisoku = 184
max_n = 20
cumpus = list(''.rjust(20,'0'))
ratio = 0.3

print 'kisoku:{0}'.format(kisoku)

next_cumpus = list(''.rjust(len(cumpus),'0'))
kisoku_bin = bin(kisoku)[2:].rjust(8,'0')
dic = {}
for n in range(8):
    dic[bin(n)[2:].rjust(3,'0')] = kisoku_bin[7-n]
    print bin(n)[2:].rjust(3,'0'),kisoku_bin[7-n]

def get_next(n):
    if n+1 == len(cumpus):
        return cumpus[0]
    return cumpus[n+1]

def regen(n):
    p = cumpus[n-1]
    c = cumpus[n]
    n = get_next(n)
    pattern = p+c+n
    return dic[pattern]

def cumpusing(s):
    length = len(cumpus)
    kuro = round(s*length)
    if kuro > length:
        kuro = length
    while kuro != cumpus.count('1'):
        n = random.randint(0,length-1)
        cumpus[n] = '1'

def mew():
    global cumpus
    print ''.join(cumpus)
    for n in range(max_n):
        for m in range(len(cumpus)):
            next_cumpus[m] = regen(m)
        print ''.join(next_cumpus)
        cumpus = next_cumpus

if __name__ == '__main__':
    for ratio in (0.3, 0.5,0.7):
        print '\nratio:{0}'.format(ratio)
        cumpusing(ratio)
        mew()
