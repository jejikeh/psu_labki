#include <string>
#include "project_manager.hxx"
#include "models/user.hxx"
#include "models/comment.hxx"
#include "models/file_type.hxx"
#include "models/attachment.hxx"

ProjectManager::ProjectManager()
{
    sql_manager = std::make_unique<SQLManager>(PROJECT_MANAGER_CONNECTION_STRING);
}

void ProjectManager::init_table() const
{
    execute_sql(Role::to_create_table_sql(), false);
    execute_sql(User::to_create_table_sql(), false);
    execute_sql(Comment::to_create_table_sql(), false);
    execute_sql(FileType::to_create_table_sql(), false);
    execute_sql(Attachment::to_create_table_sql(), false);
}

void ProjectManager::drop_table() const
{
    const auto drop_sql_query = [](const std::string& table_name) { return "DROP TABLE IF EXISTS " + table_name + " CASCADE;"; };

    execute_sql(drop_sql_query(User::s_table_name()), false);
    execute_sql(drop_sql_query(Role::s_table_name()), false);
    execute_sql(drop_sql_query(Comment::s_table_name()), false);
    execute_sql(drop_sql_query(FileType::s_table_name()), false);
    execute_sql(drop_sql_query(Attachment::s_table_name()), false);
}

pqxx::result ProjectManager::execute_sql(const std::string& sql, const bool throw_on_error) const
{
    const auto result = sql_manager->execute(sql);

    if (throw_on_error && result.affected_rows() == 0)
    {
        throw std::runtime_error("Failed to execute SQL query: " + sql);
    }

    return result;
}

void ProjectManager::create_model(const Model& entity) const
{
    execute_sql(entity.to_insert_sql());
}