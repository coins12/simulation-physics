#coding: utf-8
import random

class CA:
    
    def __init__(self, rule = 184, table_size = 20):
        self.rule_no = rule
        self.table = [0] * table_size
    def _get_next_elem(self, i):
        pattern = (self.table[i - 1] << 2) + (self.table[i] << 1) + (self.table[(i + 1) % len(self.table)])
        return ((self.rule_no & (1 << pattern)) >> pattern)
    def shift_next_state(self):
        self.table = [self._get_next_elem(i) for i in xrange(len(self.table))]
    def init_state(self, dens):
        for i in xrange(len(self.table)):
            if random.random() < dens:
                self.table[i]  = 1
            else:
                self.table[i] = 0
    def print_state(self, t, f):
        for e in self.table:
            print (e and t or f),

if __name__ == "__main__":
   for density in (0.3, 0.5,  0.7):
       ca = CA(rule = 184, table_size = 20)
       ca.init_state(dens = density)

       print "Density = %0.1f" % density
       for t in xrange(20):
           print "t = %2d: " % (t),
           ca.print_state("1", "0")
           print
           ca.shift_next_state()


