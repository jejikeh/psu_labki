#pragma once

#include <string>
#include <utility>
#include "model.hxx"
#include "role.hxx"

class User final : public Model
{
public:
    std::string name;
    std::string email;
    std::string password;
    std::string fk_role_id;

    User() = default;

    User(std::string name, std::string email, std::string password)
        : name(std::move(name)), email(std::move(email)), password(std::move(password))
    {
        id = std::to_string(rand());
    }

    void assign_role(const Role& role)
    {
        fk_role_id = role.id;
    }

    [[nodiscard]] std::string to_insert_sql() const override
    {
        return "INSERT INTO " + table_name() + " VALUES (" + id + ", '" + name + "', '" + email + "', '" + password + "', '" + fk_role_id +
               "');";
    }

    static constexpr std::string s_table_name()
    {
        return "users";
    }

    [[nodiscard]] std::string table_name() const override
    {
        return s_table_name();
    }

    void from_pqxx_row(const pqxx::row& row) override
    {
        id = row["id"].as<std::string>();
        name = row["name"].as<std::string>();
        email = row["email"].as<std::string>();
        password = row["password"].as<std::string>();
        fk_role_id = row["fk_role_id"].as<std::string>();
    }

    static constexpr std::string to_create_table_sql()
    {
        return "CREATE TABLE users ("
               "id TEXT PRIMARY KEY, "
               "name TEXT, "
               "email TEXT, "
               "password TEXT, "
               "fk_role_id TEXT REFERENCES roles(id));";
    }
};