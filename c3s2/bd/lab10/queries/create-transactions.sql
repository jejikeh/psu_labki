BEGIN;
INSERT INTO projects (project_name, start_date, end_date)
VALUES ('New Project', '2024-06-01', '2024-12-31');

WITH new_project_id AS (
    SELECT project_id
    FROM projects
    WHERE project_name = 'New Project'
)
INSERT INTO tasks (task_name, description, project_id, employee_id, deadline, status)
SELECT 'Task 1', 'New task for the project', np.project_id, 2, '2024-07-01', 'Not Started'
FROM new_project_id np;
COMMIT;

BEGIN;
UPDATE tasks
SET employee_id = 3
WHERE task_name = 'Task 1';
COMMIT;

BEGIN;
UPDATE tasks
SET status = 'In Progress'
WHERE task_name = 'Task 1';
COMMIT;

BEGIN;
DELETE FROM projects
WHERE project_name = 'Project D';
COMMIT;

BEGIN;
DELETE FROM tasks
WHERE employee_id = 5;
COMMIT;
