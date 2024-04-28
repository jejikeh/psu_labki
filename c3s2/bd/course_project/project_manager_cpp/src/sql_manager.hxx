#pragma once

#include <pqxx/pqxx>
#include <memory>
#include "models/user.hxx"

class SQLManager
{
public:
    explicit SQLManager(const std::string& connection_string);

    [[nodiscard]] pqxx::result execute(const std::string& query) const;

private:
    std::unique_ptr<pqxx::connection> m_connection;

    inline void terminate_if_lost_connection() const;
};
