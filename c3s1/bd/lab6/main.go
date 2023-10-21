package main

import (
	"flag"
	"log"
	"os"
)

func main() {
	dbhost := flag.String("db", "", "database host")
	host := flag.String("host", "", "host")
	flag.Parse()

	if *dbhost == "" {
		flag.Usage()
		os.Exit(1)
	}

	store, err := NewPostgresStorage(dbhost)
	if err != nil {
		log.Fatalf("Unable to connect to database: %v\n", err)
		os.Exit(1)
	}
	defer store.Close()

	err = store.InitTables()
	if err != nil {
		log.Fatalf("Unable to initialize tables: %v\n", err)
		os.Exit(1)
	}

	server := NewApiServer(*host, store)
	server.Run()

	/*
		defer conn.Close(context.Background())

		createProjectTable(conn)

		project := models.ProjectCreateDto{
			Name:        "test",
			Description: "test",
		}

		pk := insertProject(conn, project)
		log.Printf("Project id: %d\n", pk)

		queryProject(conn, pk)
		queryProjects(conn)
	*/
}
