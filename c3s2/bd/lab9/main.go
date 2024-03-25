package main

import (
	"flag"
	"log"
)

func main() {
	dbHost := flag.String("db", "postgres://lab9:lab9@localhost:5432/lab9", "db host")

	flag.Parse()

	s, err := NewStorage(dbHost)

	if err != nil {
		log.Fatal(err)
	}

	execDbFunc("queries/drop-table.sql", s.ExecQueryFromFile)

	execDbFunc("queries/create-table.sql", s.ExecQueryFromFile)
	execDbFunc("queries/create-users.sql", s.ExecQueryFromFile)
	execDbFunc("queries/grant.sql", s.ExecQueryFromFile)
}

func execDbFunc(s string, f func(string) error) {
	err := f(s)

	if err != nil {
		log.Fatal(err)
	}
}
