#pragma once

#include "models/model.hxx"
#include "models/project.hxx"
#include "models/project_details.hxx"
#include "sql_manager.hxx"
#include <memory>

#define PROJECT_MANAGER_CONNECTION_STRING "postgres://lablab6:lablab6@localhost:5432/lablab6"

class Attachment;

struct UserRoleInfo
{
public:
    std::string name;
    std::string email;
    std::string role_name;

    void from_pqxx_row(const pqxx::row& row)
    {
        name = row["name"].as<std::string>();
        email = row["email"].as<std::string>();
        role_name = row["role_name"].as<std::string>();
    }
};

struct UserFile
{
public:
    std::string file_name;
    std::string file_type;

    void from_pqxx_row(const pqxx::row& row)
    {
        file_name = row["file_name"].as<std::string>();
        file_type = row["file_type"].as<std::string>();
    }
};

struct ProjectTask
{
public:
    std::string stage_title;
    std::string task_title;

    void from_pqxx_row(const pqxx::row& row)
    {
        stage_title = row["stage_title"].as<std::string>();
        task_title = row["task_title"].as<std::string>();
    }
};

struct ProjectTaskDetails
{
public:
    std::string task_title;
    std::string status_title;
    std::string tag;

    void from_pqxx_row(const pqxx::row& row)
    {
        task_title = row["task_title"].as<std::string>();
        status_title = row["status_title"].as<std::string>();
        tag = row["tag"].as<std::string>();
    }
};

struct UserCommentCount
{
public:
    std::string user_id;
    std::int32_t comment_count;

    void from_pqxx_row(const pqxx::row& row)
    {
        user_id = row["user_id"].as<std::string>();
        comment_count = row["comment_count"].as<std::int32_t>();
    }
};

struct ProjectSearch
{
public:
    std::unique_ptr<Project> project;
    std::unique_ptr<ProjectDetails> project_details;
};

struct ProjectTeamsCount
{
public:
    std::string project_id;
    std::int32_t teams_count;

    void from_pqxx_row(const pqxx::row& row)
    {
        project_id = row["project_id"].as<std::string>();
        teams_count = row["teams_count"].as<std::int32_t>();
    }
};

class ProjectManager
{
public:
    std::unique_ptr<SQLManager> sql_manager;

    ProjectManager();

    void init_table() const;
    void drop_table() const;

    void create_model(const ModelEntity& entity) const;

    template <class T> std::shared_ptr<T> get_entity_by_id(const T* entity) const
    {
        auto model = static_cast<const ModelEntity*>(entity);

        if (model == nullptr)
        {
            return nullptr;
        }

        const auto sql = "SELECT * FROM " + model->table_name() + " WHERE id = '" + model->id + "';";

        auto result = execute_sql(sql, false);

        if (result.empty())
        {
            return nullptr;
        }

        auto returned_model = std::make_shared<T>();
        returned_model->from_pqxx_row(result[0]);

        return returned_model;
    }

    template <class T> void delete_entity_by_id(const std::string& id) const
    {
        const auto sql = "DELETE FROM " + T::s_table_name() + " WHERE id = '" + id + "';";

        execute_sql(sql, false);
    }

    void forget_sql(const std::string& sql) const
    {
        execute_sql(sql, false);
    }

    template <class T> std::vector<std::shared_ptr<T>> map_sql(const std::string& sql) const
    {
        auto result = execute_sql(sql, false);

        auto returned_model = std::vector<std::shared_ptr<T>>();

        for (const auto& row : result)
        {
            auto model = std::make_shared<T>();
            model->from_pqxx_row(row);

            returned_model.push_back(model);
        }

        return returned_model;
    }

    template <class T> std::vector<std::shared_ptr<T>> get_all_entities() const
    {
        const auto sql = "SELECT * FROM " + T::s_table_name() + ";";

        auto result = execute_sql(sql, false);

        auto returned_model = std::vector<std::shared_ptr<T>>();

        for (const auto& row : result)
        {
            auto model = std::make_shared<T>();
            model->from_pqxx_row(row);

            returned_model.push_back(model);
        }

        return returned_model;
    }

    std::vector<std::shared_ptr<Attachment>> get_attachment_from_user_bigger_than(std::int32_t size);
    std::vector<std::shared_ptr<UserRoleInfo>> get_user_roles();
    std::vector<std::shared_ptr<UserFile>> get_user_files(const User& user);
    std::vector<std::shared_ptr<ProjectTask>> get_project_tasks(const Project& project);
    std::vector<std::shared_ptr<ProjectTaskDetails>> get_project_task_details(const Project& project);
    std::vector<std::shared_ptr<UserCommentCount>> get_user_comment_counts(const User& project);
    std::vector<std::shared_ptr<ProjectTeamsCount>> get_project_teams_counts(const Project& project);

    std::vector<std::shared_ptr<ProjectSearch>> search_projects_by_title(const std::string& title);

private:
    pqxx::result execute_sql(const std::string& sql, bool throw_on_error = true) const;
};
