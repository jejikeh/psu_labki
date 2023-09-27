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

	n, err := strconv.Atoi(w1)

	if err != nil {
		panic(err)
	}

	for i := 1; i < n; i++ {
		for j := 1; j < n; j++ {
			if (i*j)%n == 1 {
				fmt.Printf("Обратный: %d, Обратимый: %d \n", i, j)
			}
		}
	}
}
