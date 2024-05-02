#pragma once

#include "model.hxx"
#include "project.hxx"
#include <pqxx/pqxx>

class ProjectDetails final : public ModelEntity
{
public:
    std::string fk_project_id;
    std::string title;
    std::string description;
    std::string created_at;

    ProjectDetails() = default;

    ProjectDetails(std::string title, std::string description) : title(std::move(title)), description(std::move(description))
    {

        id = std::to_string(std::hash<std::string>()(this->title));
        created_at = std::to_string(std::time(nullptr));
    }

    ProjectDetails(const std::string& title, const std::string& description, const std::string& created_at)
    {
        this->id = std::to_string(std::hash<std::string>()(title));
        this->title = title;
        this->description = description;
        this->created_at = created_at;
    }

    void assign_project(const Project& project)
    {
        fk_project_id = project.id;
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "project_details";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        fk_project_id = row["fk_project_id"].as<std::string>();
        title = row["title"].as<std::string>();
        description = row["description"].as<std::string>();
        created_at = row["created_at"].as<std::string>();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, fk_project_id, title, description, created_at) VALUES ('" + id + "', '" +
               fk_project_id + "', '" + title + "', '" + description + "', '" + created_at + "');";
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() + " (id TEXT PRIMARY KEY, fk_project_id TEXT REFERENCES " +
               Project::s_table_name() + "(id), title TEXT NOT NULL, description TEXT, created_at TEXT NOT NULL);";
    }
};