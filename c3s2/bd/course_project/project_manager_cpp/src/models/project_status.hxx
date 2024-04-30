#pragma once

#include <pqxx/pqxx>
#include "model.hxx"

class ProjectStatus final : public ModelEntity
{
public:
    std::string title;
    std::string description;

    ProjectStatus() = default;

    ProjectStatus(std::string title, std::string description) : title(std::move(title)), description(std::move(description))
    {
        id = std::to_string(time(nullptr));
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "project_statuses";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        title = row["title"].as<std::string>();
        description = row["description"].as<std::string>();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, title, description) VALUES ('" + id + "', '" + title + "', '" + description + "');";
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY, "
               "title TEXT UNIQUE, "
               "description TEXT NOT NULL);";
    }
};