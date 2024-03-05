SELECT * FROM users
WHERE years > ANY (SELECT years FROM users WHERE fk_role_id = (SELECT id FROM roles WHERE title_int = '2'));
