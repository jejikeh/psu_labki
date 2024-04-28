#pragma once

#include <pqxx/pqxx>
#include "task.hxx"

class TaskTag final : public Model
{
public:
    std::string tag;
    std::string fk_task_id;

    TaskTag() = default;

    TaskTag(std::string tag) : tag(std::move(tag))
    {
        id = std::to_string(std::hash<std::string>{}(tag));
    }

    void assign_to_task(const Task& tast)
    {
        fk_task_id = tast.id;
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "task_tags";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " VALUES ('" + id + "', '" + tag + "', '" + fk_task_id + "');";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        tag = row["tag"].as<std::string>();
        fk_task_id = row["fk_task_id"].as<std::string>();
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY, "
               "tag TEXT NOT NULL, "
               "fk_task_id TEXT NOT NULL REFERENCES " +
               Task::s_table_name() + "(id));";
    }
};