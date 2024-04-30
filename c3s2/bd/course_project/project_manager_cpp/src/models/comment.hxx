#pragma once

#include "user.hxx"
#include "model.hxx"

class Comment final : public ModelEntity
{
public:
    std::string fk_author_id;
    std::string content;
    std::string created_at;

    Comment() = default;

    Comment(std::string content) : content(std::move(content))
    {
        id = std::to_string(rand());
        created_at = std::to_string(time(nullptr));
    }

    void assign_author(const User& user)
    {
        fk_author_id = user.id;
    }

    static constexpr std::string s_table_name()
    {
        return "comments";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " (id, fk_author_id, content, created_at) VALUES ('" + id + "', '" + fk_author_id + "', '" +
               content + "', '" + created_at + "');";
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        fk_author_id = row["fk_author_id"].as<std::string>();
        content = row["content"].as<std::string>();
        created_at = row["created_at"].as<std::string>();
    }

    static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE comments ("
               "id TEXT PRIMARY KEY, "
               "fk_author_id TEXT REFERENCES users(id), "
               "content TEXT, "
               "created_at TEXT);";
    }
};