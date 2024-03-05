package main

import (
	"flag"
	"fmt"
	"math/rand"

	"github.com/jackc/pgx"
)

func main() {
	dbHost := flag.String("db", "postgres://lab1-selects-agregations:lab1-selects-agregations@localhost:5432/lab1-selects-agregations", "db host")

	flag.Parse()

	storage, err := NewStorage(dbHost)

	if err != nil {
		panic(err)
	}

	err = storage.Clear()

	if err != nil {
		panic(err)
	}

	err = storage.IniTables()

	if err != nil {
		panic(err)
	}

	err = storage.SeedData()

	if err != nil {
		panic(err)
	}

	// 1. Get Average Age of Users

	avg, err := storage.SelectHelloDescription()

	fmt.Println("1. " + avg)

	defer storage.db.Close()
}

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

func (s *Storage) Clear() error {
	query := dropSchemaQuery()
	_, err := s.db.Exec(query)

	return err
}

func (s *Storage) IniTables() error {
	query := createSchemaQuery()
	_, err := s.db.Exec(query)

	return err
}

func (s *Storage) SeedData() error {
	for i := 0; i < 10; i++ {
		role := createRole(fmt.Sprintf("%d", i), i, fmt.Sprintf("role description %d", i))

		_, err := s.db.Exec(role)

		if err != nil {
			return err
		}
	}

	for i := 0; i < 10; i++ {
		role := createUser(fmt.Sprintf("%d", i), fmt.Sprintf("user name %d", i), fmt.Sprintf("user email %d", i), i, rand.Intn(9))

		_, err := s.db.Exec(role)

		if err != nil {
			return err
		}
	}

	for i := 0; i < 10; i++ {
		role := createComments(fmt.Sprintf("%d", i), fmt.Sprintf("%d", rand.Intn(9)), fmt.Sprintf("comment content %d", i))

		_, err := s.db.Exec(role)

		if err != nil {
			return err
		}
	}

	for i := 0; i < 10; i++ {
		role := createComments(fmt.Sprintf("%d", i+10), fmt.Sprintf("%d", rand.Intn(9)), fmt.Sprintf("Hello %d", i))

		_, err := s.db.Exec(role)

		if err != nil {
			return err
		}
	}

	return nil
}

func (s *Storage) SelectHelloDescription() (string, error) {
	query := `SELECT * FROM users
WHERE fk_role_id IN (SELECT id FROM roles WHERE description = 'role description 0');
`

	var id string
	var name string
	var email string
	var years int32
	var fk_role_id string
	err := s.db.QueryRow(query).Scan(&id, &name, &email, &years, &fk_role_id)

	return fmt.Sprintf("|%s\t |%s\t |%s\t |%d\t |%s", id, name, email, years, fk_role_id), err
}

func createSchemaQuery() string {
	return `	
			CREATE TABLE IF NOT EXISTS roles (
				id TEXT PRIMARY KEY,
				title_int INT UNIQUE NOT NULL,
				description TEXT
			);

			CREATE TABLE IF NOT EXISTS users (
				id TEXT PRIMARY KEY,
				name TEXT NOT NULL,
				email TEXT,
				years INT NOT NULL,

				fk_role_id TEXT NOT NULL,
				FOREIGN KEY (fk_role_id) REFERENCES roles(id) 
			);

			CREATE TABLE IF NOT EXISTS comments (
				id TEXT PRIMARY KEY,

				fk_author_id TEXT NOT NULL,
				FOREIGN KEY (fk_author_id) REFERENCES users(id),

				content TEXT NOT NULL
			);
	`
}

func createRole(id string, title int, description string) string {
	return fmt.Sprintf("INSERT INTO roles (id, title_int, description) VALUES ('%s', %d, '%s')", id, title, description)
}

func createUser(id string, name string, email string, year int, roleId int) string {
	return fmt.Sprintf("INSERT INTO users (id, name, email, years, fk_role_id) VALUES ('%s', '%s', '%s', %d, '%d')", id, name, email, year, roleId)
}

func createComments(id string, authorId string, content string) string {
	return fmt.Sprintf("INSERT INTO comments (id, fk_author_id, content) VALUES ('%s', '%s', '%s')", id, authorId, content)
}

func dropSchemaQuery() string {
	return `DROP SCHEMA public CASCADE;
CREATE SCHEMA public;`
}
