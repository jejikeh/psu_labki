#pragma once

#include <string>
#include <utility>
#include "model.hxx"

class Role final : public ModelEntity
{
public:
    std::string name;
    std::string description;
    std::int32_t priority = 0;

    Role() = default;

    Role(std::string name, std::string description, std::int32_t priority)
        : name(std::move(name)), description(std::move(description)), priority(priority)
    {
        id = std::to_string(rand());
    }

    static constexpr std::string s_table_name()
    {
        return "roles";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, name, description, priority) VALUES ('" + id + "', '" + name + "', '" + description +
               "', " + std::to_string(priority) + ")";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        name = row["name"].as<std::string>();
        description = row["description"].as<std::string>();
        priority = row["priority"].as<std::int32_t>();
    }

    static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() + " (id TEXT PRIMARY KEY, name TEXT, description TEXT, priority INTEGER)";
    }
};