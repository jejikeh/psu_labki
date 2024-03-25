CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY,
    ProjectName VARCHAR(50),
    StartDate DATE,
    EndDate DATE
);

INSERT INTO Projects (ProjectID, ProjectName, StartDate, EndDate)
VALUES 
    (1, 'Project A', '2024-01-01', '2024-06-30'),
    (2, 'Project B', '2024-02-01', '2024-08-31'),
    (3, 'Project C', '2024-03-01', '2024-09-30'),
    (4, 'Project D', '2024-04-01', '2024-10-31'),
    (5, 'Project E', '2024-05-01', '2024-11-30');


CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Position VARCHAR(50)
);

INSERT INTO Employees (EmployeeID, FirstName, LastName, Position)
VALUES 
    (1, 'John', 'Doe', 'Project Manager'),
    (2, 'Jane', 'Smith', 'Software Developer'),
    (3, 'Michael', 'Johnson', 'QA Engineer'),
    (4, 'Emily', 'Williams', 'Business Analyst'),
    (5, 'David', 'Brown', 'UI/UX Designer');

CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY,
    TaskName VARCHAR(100),
    Description TEXT,
    ProjectID INT,
    EmployeeID INT,
    Deadline DATE,
    Status VARCHAR(20),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Tasks (TaskID, TaskName, Description, ProjectID, EmployeeID, Deadline, Status)
VALUES 
    (1, 'Task 1', 'Develop module X', 1, 2, '2024-03-15', 'In Progress'),
    (2, 'Task 2', 'Write test cases for module Y', 2, 3, '2024-03-20', 'Pending'),
    (3, 'Task 3', 'Create database schema', 3, 4, '2024-03-25', 'Completed'),
    (4, 'Task 4', 'Design user interface', 4, 5, '2024-03-30', 'In Progress'),
    (5, 'Task 5', 'Gather requirements from stakeholders', 5, 1, '2024-04-05', 'Pending');

CREATE TABLE Reports (
    ReportID INT PRIMARY KEY,
    ReportName VARCHAR(100),
    ProjectID INT,
    EmployeeID INT,
    ReportDate DATE,
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Reports (ReportID, ReportName, ProjectID, EmployeeID, ReportDate)
VALUES 
    (1, 'Weekly Progress Report', 1, 1, '2024-03-15'),
    (2, 'Monthly Status Report', 2, 2, '2024-03-25'),
    (3, 'Sprint Review Report', 3, 3, '2024-04-05'),
    (4, 'Client Meeting Minutes', 4, 4, '2024-04-10'),
    (5, 'Quality Assurance Report', 5, 5, '2024-04-15');


CREATE TABLE project_log (
    log_id SERIAL PRIMARY KEY,
    projectid INT,
    action VARCHAR(100),
    timestamp TIMESTAMP
);

CREATE TABLE employee_info (
    employeeid INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    position VARCHAR(50),
    lastupdated TIMESTAMP
);

CREATE TABLE employee_log (
    log_id SERIAL PRIMARY KEY,
    employeeid INT,
    action VARCHAR(100),
    timestamp TIMESTAMP
);
