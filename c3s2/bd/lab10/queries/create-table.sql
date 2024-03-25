CREATE TABLE projects (
    project_id SERIAL PRIMARY KEY,
    project_name VARCHAR(100),
    start_date DATE,
    end_date DATE
);

CREATE TABLE tasks (
    task_id SERIAL PRIMARY KEY,
    task_name VARCHAR(100),
    description TEXT,
    project_id INT,
    employee_id INT,
    deadline DATE,
    status VARCHAR(20)
);

CREATE TABLE employees (
    employee_id SERIAL PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    position VARCHAR(50)
);

INSERT INTO projects (project_name, start_date, end_date)
VALUES
    ('Project A', '2024-01-01', '2024-03-31'),
    ('Project B', '2024-02-15', '2024-05-30'),
    ('Project C', '2024-03-10', '2024-06-15'),
    ('Project D', '2024-04-20', '2024-07-31'),
    ('Project E', '2024-05-05', '2024-08-15');

INSERT INTO employees (first_name, last_name, position)
VALUES
    ('John', 'Doe', 'Project Manager'),
    ('Alice', 'Smith', 'Developer'),
    ('Bob', 'Johnson', 'Designer'),
    ('Emma', 'Wilson', 'Tester'),
    ('Michael', 'Brown', 'Analyst');

INSERT INTO tasks (task_name, description, project_id, employee_id, deadline, status)
VALUES
    ('Task 1', 'Develop feature X', 1, 2, '2024-02-15', 'In Progress'),
    ('Task 2', 'Design UI for website', 3, 3, '2024-03-20', 'Not Started'),
    ('Task 3', 'Write documentation', 2, 1, '2024-04-10', 'Not Started'),
    ('Task 4', 'Test new module', 4, 4, '2024-05-01', 'Not Started'),
    ('Task 5', 'Analyze market trends', 5, 5, '2024-06-01', 'Not Started');
