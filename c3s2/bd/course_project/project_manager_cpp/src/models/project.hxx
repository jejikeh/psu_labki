#pragma once

#include "model.hxx"
#include "project_stage.hxx"
#include "project_status.hxx"

class Project final : public ModelEntity
{
public:
    std::string fk_project_status_id;
    std::string fk_project_stage_id;

    Project()
    {
        id = std::to_string(time(nullptr));
    }

    void assign_project_status(const ProjectStatus& project_status)
    {
        fk_project_status_id = project_status.id;
    }

    void assign_project_stage(const ProjectStage& project_stage)
    {
        fk_project_stage_id = project_stage.id;
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "projects";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + s_table_name() + " (id, fk_project_status_id, fk_project_stage_id) VALUES ('" + id + "' , '" +
               fk_project_status_id + "' , '" + fk_project_stage_id + "')";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        fk_project_status_id = row["fk_project_status_id"].as<std::string>();
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY,"
               "fk_project_status_id TEXT REFERENCES " +
               ProjectStatus::s_table_name() +
               "(id),"
               "fk_project_stage_id TEXT REFERENCES " +
               ProjectStage::s_table_name() + "(id))";
    }
};