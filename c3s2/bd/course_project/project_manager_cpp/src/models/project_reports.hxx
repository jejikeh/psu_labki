#pragma once

#include "model.hxx"
#include "report.hxx"
#include "project.hxx"

class ProjectReports final : public Model
{
public:
    std::string fk_report_id;
    std::string fk_project_id;

    ProjectReports()
    {
        id = std::to_string(time(nullptr));
    }

    void assign_report_and_project(const Report& report, const Project& project)
    {
        fk_report_id = report.id;
        fk_project_id = project.id;
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "project_reports";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        fk_report_id = row["fk_report_id"].as<std::string>();
        fk_project_id = row["fk_project_id"].as<std::string>();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, fk_report_id, fk_project_id) VALUES ('" + id + "', '" + fk_report_id + "', '" +
               fk_project_id + "')";
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY, "
               "fk_report_id TEXT REFERENCES " +
               Report::s_table_name() +
               "(id), "
               "fk_project_id TEXT REFERENCES " +
               Project::s_table_name() + "(id));";
    }
};