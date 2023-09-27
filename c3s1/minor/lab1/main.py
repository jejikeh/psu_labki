import random
from enum import Enum
class DIR(Enum):
    RIGHT = 0
    DOWN = 1
    LEFT = 2
    UP = 3

dir = DIR.RIGHT

n = int(input())
rr = n
num = 0
arr = [[0] * n for _ in range(n)]
x, y = 0, 0
r = 1

while num < pow(n, 2):
    if (dir == DIR.RIGHT):
        while (x < n - r):
            arr[y][x] = num
            x += 1
            num += 1

        dir = DIR.DOWN
    if (dir == DIR.DOWN):
        while (y < n - r):
            arr[y][x] = num
            y += 1
            num += 1

        dir = DIR.LEFT
    if (dir == DIR.LEFT):
        while (x > n - rr):
            arr[y][x] = num
            x -= 1
            num += 1

        dir = DIR.UP
        r += 1
        rr -= 1
    if (dir == DIR.UP):
        while (y > n - rr):
            arr[y][x] = num
            y -= 1
            num += 1

        dir = DIR.RIGHT

    if num + 1 == pow(n, 2):
        arr[y][x] = num
        num += 1

for row in arr:
    print("\t".join(map(str, row)))