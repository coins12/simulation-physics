import random

kisoku = 184
max_n = 10
cumpus = list('10101101')

ran = random.seed(193)

print 'kisoku:{0}'.format(kisoku)

next_cumpus = list(''.rjust(len(cumpus),'0'))
kisoku_bin = bin(kisoku)[2:].rjust(8,'0')
dic = {}
for n in range(8):
    dic[bin(n)[2:].rjust(3,'0')] = kisoku_bin[7-n]
    print bin(n)[2:].rjust(3,'0'),kisoku_bin[7-n]

def prev(n):
    return cumpus[n-1]

def next(n):
    if n+1 == len(cumpus):
        return cumpus[0]
    return cumpus[n+1]

def regen(n):
    p = prev(n)
    c = cumpus[n]
    n = next(n)
    pattern = p+c+n
    return dic[pattern]

if __name__ == '__main__':
    print ''.join(cumpus)
    for n in range(max_n):
        for m in range(len(cumpus)):
            next_cumpus[m] = regen(m)
        print ''.join(next_cumpus)
        cumpus = next_cumpus
