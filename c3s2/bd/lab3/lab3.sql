-- INNER JOIN
SELECT users.name, roles.title_int
FROM users
INNER JOIN roles ON users.fk_role_id = roles.id;

-- LEFT JOIN
SELECT users.name, roles.title_int
FROM users
LEFT JOIN roles ON users.fk_role_id = roles.id;

-- RIGHT JOIN
SELECT users.name, roles.title_int
FROM users
RIGHT JOIN roles ON users.fk_role_id = roles.id;

-- FULL JOIN
SELECT users.name, roles.title_int
FROM users
FULL JOIN roles ON users.fk_role_id = roles.id;

-- CROSS JOIN
SELECT users.name, roles.title_int
FROM users
CROSS JOIN roles;

-- UNION
SELECT name, email
FROM users
UNION
SELECT fk_author_id AS name, null AS email
FROM comments;

-- EXCEPT
SELECT name, email
FROM users
EXCEPT
SELECT fk_author_id AS name, null AS email
FROM comments;

-- INTERSECT
SELECT id, name, email
FROM users
WHERE id IN (
    SELECT id
    FROM users
    INTERSECT
    SELECT fk_author_id
    FROM comments
);
