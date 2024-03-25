-- Создание схем
CREATE SCHEMA projects_schema;
CREATE SCHEMA tasks_schema;
CREATE SCHEMA employees_schema;

-- Создание таблиц в каждой схеме
CREATE TABLE projects_schema.projects (
    project_id SERIAL PRIMARY KEY,
    project_name VARCHAR(100),
    start_date DATE,
    end_date DATE
);

CREATE TABLE tasks_schema.tasks (
    task_id SERIAL PRIMARY KEY,
    task_name VARCHAR(100),
    description TEXT,
    project_id INT REFERENCES projects_schema.projects(project_id),
    employee_id INT,
    deadline DATE,
    status VARCHAR(20)
);

CREATE TABLE employees_schema.employees (
    employee_id SERIAL PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    position VARCHAR(50)
);

-- Заполнение таблиц тестовыми данными
INSERT INTO projects_schema.projects (project_name, start_date, end_date)
VALUES
    ('Project 1', '2024-01-01', '2024-03-31'),
    ('Project 2', '2024-02-15', '2024-05-30'),
    ('Project 3', '2024-03-10', '2024-06-15');

INSERT INTO employees_schema.employees (first_name, last_name, position)
VALUES
    ('John', 'Doe', 'Project Manager'),
    ('Alice', 'Smith', 'Developer'),
    ('Bob', 'Johnson', 'Designer');

INSERT INTO tasks_schema.tasks (task_name, description, project_id, employee_id, deadline, status)
VALUES
    ('Task 1', 'Develop feature X', 1, 2, '2024-02-15', 'In Progress'),
    ('Task 2', 'Design UI for website', 3, 3, '2024-03-20', 'Not Started');
