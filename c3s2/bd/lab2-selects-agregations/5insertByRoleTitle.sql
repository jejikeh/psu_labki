DELETE FROM comments
WHERE fk_author_id IN (SELECT id FROM users WHERE fk_role_id = (SELECT id FROM roles WHERE title_int = '6'));
