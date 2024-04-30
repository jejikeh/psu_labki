#pragma once

#include <pqxx/pqxx>
#include "model.hxx"

class Report final : public ModelEntity
{
public:
    std::int32_t value;
    std::string description;

    Report() = default;

    Report(std::int32_t value, std::string description) : value(value), description(std::move(description))
    {
        id = std::to_string(time(nullptr));
    }

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "reports";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        value = row["value"].as<std::int32_t>();
        description = row["description"].as<std::string>();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, value, description) VALUES ('" + id + "', " + std::to_string(value) + ", '" +
               description + "');";
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() + "(id TEXT PRIMARY KEY, value INTEGER, description TEXT);";
    }
};