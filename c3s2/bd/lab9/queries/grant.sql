-- Ограничения доступа к таблицам для ролей
REVOKE ALL ON projects_schema.projects FROM public;
GRANT SELECT, INSERT, UPDATE, DELETE ON projects_schema.projects TO project_manager;

REVOKE ALL ON tasks_schema.tasks FROM public;
GRANT SELECT, INSERT, UPDATE, DELETE ON tasks_schema.tasks TO developer, tester;

REVOKE ALL ON employees_schema.employees FROM public;
GRANT SELECT ON employees_schema.employees TO project_manager, developer, tester;

-- Ограничения доступа к схемам для ролей
REVOKE ALL ON SCHEMA projects_schema FROM public;
GRANT USAGE ON SCHEMA projects_schema TO project_manager;

REVOKE ALL ON SCHEMA tasks_schema FROM public;
GRANT USAGE ON SCHEMA tasks_schema TO developer, tester;

REVOKE ALL ON SCHEMA employees_schema FROM public;
GRANT USAGE ON SCHEMA employees_schema TO project_manager, developer, tester;
