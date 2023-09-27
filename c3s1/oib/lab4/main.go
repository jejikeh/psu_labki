package main

import (
	"fmt"
	"strconv"
)

func main() {
	fmt.Println("Input m")
	var w1 string
	_, err := fmt.Scanln(&w1)

	if err != nil {
		panic(err)
	}

	m, err := strconv.Atoi(w1)

	if err != nil {
		panic(err)
	}

	for i := 0; i < m; i++ {
		for j := 0; j < m; j++ {
			fmt.Printf("%d ", i*j%m)
		}

		fmt.Println()
	}

	for i := 0; i < m; i++ {
		if gcd(i, m)-1 != 0 {
			fmt.Printf("Делитель %d\n", i)
		}
		for j := 0; j < m; j++ {
			if (i*j)%m == 1 {
				fmt.Printf("Обратимый элемент:  %d\n", i)
			}
		}
	}
}

func gcd(a int, b int) int {
	for b != 0 {
		temp := b
		b = a % b
		a = temp
	}

	return a
}
