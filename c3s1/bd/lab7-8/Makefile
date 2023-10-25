build:
	@go build -o bin/lab6

run: build
	@./bin/lab6 -db=postgres://lablab6:lablab6@localhost:5432/lablab6 -host=:3000

test:
	@go test -v ./...