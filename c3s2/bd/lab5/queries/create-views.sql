CREATE VIEW Updateable_Projects_View AS
SELECT * FROM Projects;

CREATE VIEW NonUpdateable_Projects_View AS
SELECT ProjectID, ProjectName, StartDate, EndDate FROM Projects;



CREATE VIEW Updateable_Employees_View AS
SELECT * FROM Employees;

CREATE VIEW NonUpdateable_Employees_View AS
SELECT EmployeeID, FirstName, LastName, Position FROM Employees;



CREATE VIEW Updateable_Tasks_View AS
SELECT * FROM Tasks;

CREATE VIEW NonUpdateable_Tasks_View AS
SELECT TaskID, TaskName, Description, ProjectID, EmployeeID, Deadline, Status FROM Tasks;



CREATE VIEW Updateable_Reports_View AS
SELECT * FROM Reports;

CREATE VIEW NonUpdateable_Reports_View AS
SELECT ReportID, ReportName, ProjectID, EmployeeID, ReportDate FROM Reports;