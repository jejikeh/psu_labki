CREATE ROLE project_manager;
CREATE ROLE developer;
CREATE ROLE tester;

CREATE USER pm_user WITH PASSWORD 'password';
GRANT project_manager TO pm_user;

CREATE USER dev_user WITH PASSWORD 'password';
GRANT developer TO dev_user;

CREATE USER tester_user WITH PASSWORD 'password';
GRANT tester TO tester_user;

CREATE USER dev_tester_user WITH PASSWORD 'password';
GRANT developer TO dev_tester_user;
GRANT tester TO dev_tester_user;

CREATE USER pm_dev_user WITH PASSWORD 'password';
GRANT project_manager TO pm_dev_user;
GRANT developer TO pm_dev_user;

CREATE USER pm_tester_user WITH PASSWORD 'password';
GRANT project_manager TO pm_tester_user;
GRANT tester TO pm_tester_user;
