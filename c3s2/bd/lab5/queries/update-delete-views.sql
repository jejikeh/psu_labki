CREATE OR REPLACE VIEW Updateable_Tasks_View AS
SELECT TaskID, TaskName, Description, ProjectID, EmployeeID, Deadline, CAST('Completed' AS VARCHAR(20)) AS Status
FROM Tasks
WHERE Status = 'In Progress';

DROP VIEW NonUpdateable_Reports_View;