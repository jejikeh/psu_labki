#pragma once

#include "model.hxx"
#include <pqxx/pqxx>

class TaskStatus final : public ModelEntity
{
public:
    std::string title;
    std::string description;
    bool staging;

    TaskStatus() = default;

    TaskStatus(std::string title, std::string description, bool staging)
        : title(std::move(title)), description(std::move(description)), staging(staging)
    {
        id = std::to_string(std::hash<std::string>{}(this->title));
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "task_statuses";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " VALUES (" + id + ", '" + title + "', '" + description + "', " +
               (staging ? "true" : "false") + ");";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        title = row["title"].as<std::string>();
        description = row["description"].as<std::string>();
        staging = row["staging"].as<bool>();
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() + "(id TEXT PRIMARY KEY, title TEXT, description TEXT, staging BOOLEAN);";
    }
};