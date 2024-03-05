INSERT INTO users (id, name, email, years, fk_role_id)
VALUES ('123', 'Имя', 'email@example.com', 25, (SELECT id FROM roles WHERE title_int = '1'));
