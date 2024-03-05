SELECT * FROM comments c
WHERE EXISTS (SELECT 1 FROM users u WHERE u.id = c.fk_author_id AND u.fk_role_id = (SELECT id FROM roles WHERE title_int = '1'));
