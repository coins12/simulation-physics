#!/usr/bin/env python
# -*- coding: utf-8 -*-
import random
import math
n = 10
trying = 10000
trying_count = 0.0
random.seed()
for j in xrange(0, trying):
    count = 0
    for i in xrange(0, n):
        x = random.random() * 2
        y = random.random() * 2
        if (x - 1) ** 2 + (y - 1) ** 2 <= 1:
            count += 1
    trying_count += (4.0 * count / n) # n : count = 4 : pi

trying_count /= trying
print ""
print trying_count
print (math.pi - trying_count) / math.pi
