package main

import (
	"fmt"
	"strconv"
)

func main() {
	for {
		fmt.Println("----------\n\n\n")
		fmt.Println("Enter text: ")
		var w1 string
		_, err := fmt.Scanln(&w1)

		if err != nil {
			panic(err)
		}

		m, err := strconv.Atoi(w1)

		if err != nil {
			panic(err)
		}
		// 4)

		fmt.Println("Multiply table: ")
		mt, _ := multiplyTable(m)

		fmt.Println("4) 5) 6) ---------\n\n\n")

		frMT := calculateFreq(mt)
		rMT := sumFreq(frMT)
		fmt.Println("sumFreq = ", rMT)

		fmt.Println("---------\n\n")
		fmt.Println("Sum table: ")
		st, _ := sumTable(m)

		fmt.Println("4) 5) 6) ---------")

		frST := calculateFreq(st)
		rST := sumFreq(frST)
		fmt.Println("sumFreq = ", rST)
	}
}

func multiplyTable(m int) ([]int, int) {
	l := make([]int, 0)
	s := 0
	for i := 0; i < m; i++ {
		for j := 0; j < m; j++ {
			k := (i * j) % m
			l = append(l, k)
			fmt.Printf("%d ", k)
			if k == 0 {
				s++
				// break
			}
		}

		fmt.Println()
	}
	return l, s
}

func sumTable(m int) ([]int, int) {
	l := make([]int, m*m)
	s := 0
	for i := 0; i < m; i++ {
		for j := 0; j < m; j++ {
			k := (i + j) % m
			l = append(l, k)
			fmt.Printf("%d ", k)
			if k == 0 {
				s++
				// break
			}
		}

		fmt.Println()
	}
	return l, s
}

func calculateFreq(a []int) []float64 {
	f := map[int]int{}
	l := make([]float64, 0)

	sum := 0

	for _, v := range a {
		f[v]++
	}

	for v, k := range f {
		freq := float64(k) / float64(len(a))
		fmt.Printf("%d = %d / %f\n", v, k, freq)
		l = append(l, freq)

		sum += k
	}

	fmt.Println("Sum of all symbols = ", sum)

	return l
}

func sumFreq(a []float64) float64 {
	var f float64 = 0.0

	var min float64 = a[0]
	var max float64 = 0.0

	for _, v := range a {
		f += v

		if v > max {
			max = v
		}

		if v < min {
			min = v
		}
	}

	fmt.Println("-------------------")
	fmt.Printf("min = %f, max = %f\n", min, max)
	fmt.Printf("max / min = %f\n", max/min)

	return f
}
