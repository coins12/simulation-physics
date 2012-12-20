
Random

List create := method(n, val,
  List clone setSize(n) map(_, val)
)

stepCell := method(c1,
  c2 := c1 map(y,
    i := 0
    n := y size
    y map(x,
      l := if(i - 1 < 0, 0, y at(i - 1))
      r := if(i + 1 < n, y at(i + 1), 0)
      result := if(x == 0, l, r)
      i := i + 1
      result
    )
  )
  c2 step := method(stepCell(self))
  c2
)

createCell := method(n, m,
  cell := List create(n, List create(m, 0))
  cell step := method(stepCell(self))
  cell
)

Random

randomBit := method(percentage,
  if(Random value minMax(0, 1) < percentage, 1, 0)
)

createCellWithRandomBit := method(n, m, percentage,
  cell := createCell(n, m)
  cell := cell map(y, y map(x, randomBit(percentage)))
  cell
)

# ‰Û‘è(2) ‰Šú–§“x = 0.3
cell := createCellWithRandomBit(1, 8, 0.5)
List create(22, 0) map(v,
  r := cell at(0) reduce(x, y, x .. "," .. y)
  cell := cell step
  r
) reduce(x, y, x .. "\n" .. y) println

# ‰Û‘è(2) ‰Šú–§“x = 0.5
cell := createCellWithRandomBit(1, 8, 0.5)
List create(22, 0) map(v,
  r := cell at(0) reduce(x, y, x .. "," .. y)
  cell := cell step
  r
) reduce(x, y, x .. "\n" .. y) println

# ‰Û‘è(2) ‰Šú–§“x = 0.7
cell := createCellWithRandomBit(1, 8, 0.7)
List create(22, 0) map(v,
  r := cell at(0) reduce(x, y, x .. "," .. y)
  cell := cell step
  r
) reduce(x, y, x .. "\n" .. y) println


