-- count comments --

CREATE FUNCTION count_comments(user_id TEXT) RETURNS INT AS $$
DECLARE
    comment_count INT;
BEGIN
    SELECT COUNT(*)
    INTO comment_count
    FROM comments
    WHERE fk_author_id = user_id;

    RETURN comment_count;
END;
$$ LANGUAGE plpgsql;

SELECT count_comments('1');

-- all users which commented --

CREATE FUNCTION users_with_comment_count_fix() RETURNS TABLE (user_name TEXT, comment_count BIGINT) AS $$
BEGIN
    RETURN QUERY
    SELECT u.name, COUNT(c.id)::BIGINT
    FROM users u
    LEFT JOIN comments c ON u.id = c.fk_author_id
    GROUP BY u.name;
END;
$$ LANGUAGE plpgsql;

SELECT * FROM users_with_comment_count_fix();

--

CREATE FUNCTION user_info_with_role_fix2() RETURNS TABLE (user_name TEXT, comment_count BIGINT, role_title INT) AS $$
BEGIN
    RETURN QUERY
    SELECT u.name, COUNT(c.id), r.title_int
    FROM users u
    LEFT JOIN comments c ON u.id = c.fk_author_id
    LEFT JOIN roles r ON u.fk_role_id = r.id
    GROUP BY u.name, r.title_int;
END;
$$ LANGUAGE plpgsql;


SELECT * FROM user_info_with_role_fix2();

-- get user age

CREATE FUNCTION get_user_age(user_id TEXT) RETURNS INT AS $$
DECLARE
    user_age INT;
BEGIN
    SELECT years
    INTO user_age
    FROM users
    WHERE id = user_id;

    RETURN user_age;
END;
$$ LANGUAGE plpgsql;


SELECT get_user_age('123')  

-- get user role

CREATE FUNCTION get_roles_fix() RETURNS TABLE (role_title INT, role_description TEXT) AS $$
BEGIN
    RETURN QUERY
    SELECT title_int, description
    FROM roles;
END;
$$ LANGUAGE plpgsql;


SELECT * FROM get_roles_fix();

-- 

CREATE FUNCTION user_comments_info(user_name TEXT) RETURNS TABLE (comment_id TEXT, comment_content TEXT) AS $$
BEGIN
    RETURN QUERY
    SELECT id, content
    FROM comments
    WHERE fk_author_id = (SELECT id FROM users WHERE name = user_name);
END;
$$ LANGUAGE plpgsql;

SELECT * FROM user_comments_info('user name 0');