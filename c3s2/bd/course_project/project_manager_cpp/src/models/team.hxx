#pragma once

#include <string>
#include <pqxx/pqxx>
#include "model.hxx"
#include "project.hxx"

class Team final : public ModelEntity
{
public:
    std::string description;
    std::string fk_project_id;

    Team() = default;

    Team(std::string description) : description(std::move(description))
    {
        id = std::to_string(std::hash<std::string>{}(description));
    }

    void assign_project(const Project& project)
    {
        fk_project_id = project.id;
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "teams";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + s_table_name() + " VALUES (" + id + ", '" + description + "', '" + fk_project_id + "');";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        description = row["description"].as<std::string>();
        fk_project_id = row["fk_project_id"].as<std::string>();
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY, "
               "description TEXT, "
               "fk_project_id TEXT REFERENCES " +
               Project::s_table_name() + "(id));";
    }
};