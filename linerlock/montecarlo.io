Random
Range

montecarlo := method(n,
  hit := 0
  for(i, 0, n,
    x := Random value
    y := Random value
    if(x * x + y * y <= 1.0, hit := hit + 1))
  (hit / n) * 4
)

randomSign := method(
  if(Random value < 0.5, -1, 1)
)

plot := method(n,
  1 to(n) asList map(_,
    x := Random value minMax(0, 1.0) * randomSign
    y := Random value minMax(0, 1.0) * randomSign
    list(x, y)
  ) select(v, 
    x := v at(0)
    y := v at(1)
    x * x + y * y < 1.0
  ) map(v, 
      v at(0) .. "," .. v at(1)
  )
)

plot(200) foreach(v, v println)


