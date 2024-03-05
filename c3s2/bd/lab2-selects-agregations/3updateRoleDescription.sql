UPDATE roles
SET description = 'new description'
WHERE id = (SELECT id FROM roles WHERE title_int = '2');
