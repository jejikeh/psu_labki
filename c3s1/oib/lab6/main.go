package main

import (
	"fmt"
	"strconv"
)

func main() {

	fmt.Print("a = ")
	var w1 string

	_, err := fmt.Scanln(&w1)

	if err != nil {
		panic(err)
	}

	a, err := strconv.Atoi(w1)

	fmt.Print("b = ")
	var w2 string

	_, err = fmt.Scanln(&w2)

	if err != nil {
		panic(err)
	}

	b, err := strconv.Atoi(w2)

	fmt.Printf("НОД a=%d и b=%d равен %d\n", a, b, gcd(a, b))
}

func gcd(a int, b int) int {
	for b != 0 {
		temp := b
		b = a % b
		a = temp
	}

	return a
}
