package main

import (
	"fmt"
	"strconv"
)

func GCD(a int, b int) int {
	for b != 0 {
		temp := b
		b = a % b
		a = temp
	}

	return a
}

func main() {
	fmt.Println("Input base M ring Zm")
	var w1 string
	_, err := fmt.Scanln(&w1)

	if err != nil {
		panic(err)
	}

	m, err := strconv.Atoi(w1)

	k := m
	s := 0

	for i := 0; i < m; i++ {
		if GCD(i, m)-1 == 0 {
			continue
		}

		s = 0
		fmt.Println("Divider ", i)
		fmt.Print("\t\tDivider fom enumeration: ")
		for j := 1; j < m; j++ {
			k = (i * j) % m
			if k == 0 {
				fmt.Printf(" %d", j)
				s++
			}
		}

		fmt.Print("\n\t\tAnnihilator from threorem: ")
		for j := 1; j < GCD(i, m); j++ {
			k = j * m / GCD(i, m)
			fmt.Print(k, " ")
		}

		fmt.Println("\n\t\tCount annihilator =", s)
	}
}
