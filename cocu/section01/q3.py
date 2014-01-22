import random
import subprocess

random.seed(199)
n = ''
m = 0

while m < 200:
    x = random.random()*2-1
    y = random.random()*2-1
    if(x*x+y*y<=1):
        n+="{0}\t{1}\n".format(x,y)
        m += 1

open('q3.csv','w').write(n)
n = '''set terminal png;set nokey;set output "q3.png";set size square;set xrange[-1:1];set yrange[-1:1];plot "q3.csv"'''
subprocess.Popen(['gnuplot','-e',n])
