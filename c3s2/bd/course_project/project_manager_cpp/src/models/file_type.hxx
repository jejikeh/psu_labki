#pragma once

#include <pqxx/pqxx>
#include "model.hxx"

class FileType final : public ModelEntity
{
public:
    std::string description;
    std::string extension;

    FileType() = default;

    FileType(std::string extension, std::string description = "") : description(std::move(description)), extension(std::move(extension))
    {
        id = std::to_string(std::hash<std::string>{}(extension));
    }

    static constexpr std::string s_table_name()
    {
        return "file_types";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, description, extension) VALUES ('" + id + "', '" + description + "', '" + extension +
               "')";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        description = row["description"].as<std::string>();
        extension = row["extension"].as<std::string>();
    }

    static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE IF NOT EXISTS " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY,"
               "description TEXT NOT NULL,"
               "extension TEXT UNIQUE"
               ")";
    }
};