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

	avg, err := storage.GetAverageAge()

	if err != nil {
		panic(err)
	}

	fmt.Printf("1. Average age: \t%f\n", avg)

	// 2. Get Comments Counts

	count, err := storage.GetCommentsCount()

	if err != nil {
		panic(err)
	}

	fmt.Printf("2. Comments count: \t%d\n", count)

	// 3. Get Minimal Age

	age, err := storage.GetMinimalAge()

	if err != nil {
		panic(err)
	}

	fmt.Printf("3. Minimal age: \t%d\n", age)

	// 4. Get Most Commented User

	user, err := storage.GetMostCommentedUser()

	if err != nil {
		panic(err)
	}

	fmt.Printf("4. Max comments:\t%d\n", user)

	// 5. Sum Age

	sum, err := storage.SumAge()

	if err != nil {
		panic(err)
	}

	fmt.Printf("5. Sum age: \t\t%d\n", sum)

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

	return nil
}

func (s *Storage) GetAverageAge() (float32, error) {
	query := `SELECT AVG(years) FROM users;`

	var avg float32
	err := s.db.QueryRow(query).Scan(&avg)

	return avg, err
}

func (s *Storage) GetMinimalAge() (int32, error) {
	query := `
			SELECT MIN(years) AS min_age
			FROM users;
	`

	var age int32
	err := s.db.QueryRow(query).Scan(&age)

	return age, err
}

func (s *Storage) GetCommentsCount() (int32, error) {
	query := `
			SELECT COUNT(*) AS total_comments
			FROM comments;`

	var avg int32
	err := s.db.QueryRow(query).Scan(&avg)

	return avg, err
}

func (s *Storage) GetMostCommentedUser() (int32, error) {
	query := `
	SELECT MAX(comment_count) AS max_comments_by_user
	FROM (SELECT COUNT(*) AS comment_count
      	FROM comments
      	GROUP BY fk_author_id) AS comment_counts;
	`

	var count int32
	err := s.db.QueryRow(query).Scan(&count)

	return count, err
}

func (s *Storage) SumAge() (int32, error) {
	query := `SELECT SUM(years) FROM users;`

	var sum int32
	err := s.db.QueryRow(query).Scan(&sum)

	return sum, err
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
