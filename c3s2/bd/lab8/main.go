package main

import (
	"flag"
	"log"
)

func main() {
	dbHost := flag.String("db", "postgres://lab5:lab5@localhost:5432/lab5", "db host")

	flag.Parse()

	s, err := NewStorage(dbHost)

	if err != nil {
		log.Fatal(err)
	}

	execDbFunc("queries/drop-table.sql", s.ExecQueryFromFile)

	execDbFunc("queries/create-table.sql", s.ExecQueryFromFile)
	execDbFunc("queries/create-views.sql", s.ExecQueryFromFile)
	execDbFunc("queries/update-delete-views.sql", s.ExecQueryFromFile)
}

func execDbFunc(s string, f func(string) error) {
	err := f(s)

	if err != nil {
		log.Fatal(err)
	}
}
