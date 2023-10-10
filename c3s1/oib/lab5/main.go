package main

import (
	"fmt"
	"strconv"
)

func main() {
	fmt.Println("Input Zm")
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
		if gcd(i, m)-1 != 0 && !isSimple(i) {
			fmt.Printf("Делитель %d\n", i)
		}

		for j := 0; j < m; j++ {
			if (i*j)%m == 1 {
				fmt.Printf("Обратимый элемент:  %d\n", i)
			}
		}
	}

	if isSimple(m) {
		fmt.Printf("Основание м=%d простое число!\n", m)
	} else {
		fmt.Printf("Основание м=%d не простое число!\n", m)
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

func isSimple(number int) bool {
	if number == 0 || number == 1 {
		return false
	}
	for i := 2; i < number; i++ {
		if number%i == 0 {
			return false
		}
	}
	return true
}
