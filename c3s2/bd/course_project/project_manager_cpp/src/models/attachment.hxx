#pragma once

#include "user.hxx"
#include "model.hxx"
#include "file_type.hxx"

class Attachment final : public Model
{
public:
    std::string file_content;
    std::string fk_author_id;
    std::string fk_file_type_id;

    Attachment() = default;

    Attachment(std::string file_content) : file_content(std::move(file_content))
    {
        id = std::to_string(std::hash<std::string>{}(file_content));
    }

    static constexpr std::string s_table_name()
    {
        return "attachments";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    void assign_author_and_file_type(const User& user, const FileType& file_type)
    {
        fk_author_id = user.id;
        fk_file_type_id = file_type.id;
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " VALUES ('" + id + "', '" + file_content + "', '" + fk_author_id + "', '" +
               fk_file_type_id + "');";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        file_content = row["file_content"].as<std::string>();
        fk_author_id = row["fk_author_id"].as<std::string>();
        fk_file_type_id = row["fk_file_type_id"].as<std::string>();
    }

    [[nodiscard]] static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE " + s_table_name() +
               " ("
               "id TEXT PRIMARY KEY, "
               "file_content TEXT NOT NULL, "
               "fk_author_id TEXT NOT NULL REFERENCES " +
               User::s_table_name() +
               "(id), "
               "fk_file_type_id TEXT NOT NULL REFERENCES " +
               FileType::s_table_name() + "(id));";
    }
};