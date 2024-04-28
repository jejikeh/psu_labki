#pragma once

#include <string>
#include <utility>
#include "model.hxx"

class Role final : public Model
{
public:
    std::string name;
    std::string description;

    Role() = default;

    Role(std::string name, std::string description) : name(std::move(name)), description(std::move(description))
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
        return "INSERT INTO " + table_name() + " (id, name, description) VALUES ('" + id + "', '" + name + "', '" + description + "')";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        name = row["name"].as<std::string>();
        description = row["description"].as<std::string>();
    }

    static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() + " (id TEXT PRIMARY KEY, name TEXT, description TEXT)";
    }
};