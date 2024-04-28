#pragma once

#include "model.hxx"
#include "task_tag.hxx"
#include "task_status.hxx"
#include "team.hxx"

class Task final : public Model
{
public:
    std::string title;
    std::string description;
    std::string fk_team_id;
    std::string fk_task_status_id;

    Task() = default;

    Task(std::string title, std::string description) : title(std::move(title)), description(std::move(description))
    {
        id = std::to_string(std::hash<std::string>{}(title));
    }

    void assign_task_status(const TaskStatus& task_status)
    {
        fk_task_status_id = task_status.id;
    }

    void assign_team(const Team& team)
    {
        fk_team_id = team.id;
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "tasks";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    };

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, title, description, fk_task_status_id, fk_team_id) VALUES ('" + id + "', '" + title +
               "', '" + description + "', '" + fk_task_status_id + "', '" + fk_team_id + "');";
    }

    void from_pqxx_row(const pqxx::row& res) override
    {
        id = res["id"].as<std::string>();
        title = res["title"].as<std::string>();
        description = res["description"].as<std::string>();
        fk_task_status_id = res["fk_task_status_id"].as<std::string>();
        fk_team_id = res["fk_team_id"].as<std::string>();
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY,"
               "title TEXT NOT NULL,"
               "description TEXT,"
               "fk_task_status_id TEXT NOT NULL REFERENCES " +
               TaskStatus::s_table_name() +
               "(id),"
               "fk_team_id TEXT NOT NULL REFERENCES " +
               Team::s_table_name() + "(id)" + ");";
    }
};