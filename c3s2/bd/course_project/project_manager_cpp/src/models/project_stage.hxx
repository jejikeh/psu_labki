#pragma once

#include <utility>
#include <pqxx/pqxx>
#include "model.hxx"

class ProjectStage final : public ModelEntity
{
public:
    std::string title;
    std::string description;
    std::string start_date;
    std::string end_date;

    ProjectStage() = default;

    ProjectStage(std::string title, std::string description, std::string start_date, std::string end_date)
        : title(std::move(title)), description(std::move(description)), start_date(std::move(start_date)), end_date(std::move(end_date))
    {
        id = std::to_string(time(nullptr));
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "project_stages";
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
        start_date = row["start_date"].as<std::string>();
        end_date = row["end_date"].as<std::string>();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " VALUES ('" + id + "', '" + title + "', '" + description + "', '" + start_date + "', '" +
               end_date + "');";
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY, "
               "title TEXT, "
               "description TEXT, "
               "start_date DATE, "
               "end_date DATE);";
    }
};