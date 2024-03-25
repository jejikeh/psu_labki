package main

import (
	"os"

	"github.com/jackc/pgx"
)

type Storage struct {
	db *pgx.Conn
}

func NewStorage(connectionString *string) (*Storage, error) {
	config, err := pgx.ParseConnectionString(*connectionString)

	if err != nil {
		return nil, err
	}

	connection, err := pgx.Connect(config)

	if err != nil {
		return nil, err
	}

	return &Storage{
		db: connection,
	}, nil
}

func (s *Storage) ExecQuery(query string) error {
	_, err := s.db.Exec(query)

	return err
}

func (s *Storage) CreateTables() error {
	query, err := os.ReadFile("queries/create-table.sql")

	if err != nil {
		return err
	}

	return s.ExecQuery(string(query))
}

func (s *Storage) CreateViews() error {
	query, err := os.ReadFile("queries/create-views.sql")

	if err != nil {
		return err
	}

	return s.ExecQuery(string(query))
}

func (s *Storage) ExecQueryFromFile(path string) error {
	query, err := os.ReadFile(path)

	if err != nil {
		return err
	}

	return s.ExecQuery(string(query))
}
