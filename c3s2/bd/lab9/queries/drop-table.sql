DROP SCHEMA public CASCADE;

DROP SCHEMA projects_schema CASCADE;

DROP SCHEMA tasks_schema CASCADE;

DROP SCHEMA employees_schema CASCADE;

DROP ROLE IF EXISTS project_manager;

DROP ROLE IF EXISTS developer;

DROP ROLE IF EXISTS tester;

DROP USER IF EXISTS pm_user;

DROP USER IF EXISTS dev_user;

DROP USER IF EXISTS tester_user;

DROP USER IF EXISTS dev_tester_user;

DROP USER IF EXISTS pm_dev_user;

DROP USER IF EXISTS pm_tester_user;

CREATE SCHEMA public;