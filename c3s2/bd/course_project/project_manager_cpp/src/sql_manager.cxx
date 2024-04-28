#include "sql_manager.hxx"
#include <iostream>

SQLManager::SQLManager(const std::string& connection_string)
{
    m_connection = std::make_unique<pqxx::connection>(connection_string);

    if (!m_connection->is_open())
    {
        std::cerr << "Can't open connection to database" << std::endl;

        std::terminate();
    }
}

pqxx::result SQLManager::execute(const std::string& query) const
{
    terminate_if_lost_connection();

    pqxx::work work(*m_connection);

    const auto result = work.exec(query);

    work.commit();

    return result;
}

inline void SQLManager::terminate_if_lost_connection() const
{
    if (!m_connection->is_open())
    {
        std::cerr << "Lost connection to database" << std::endl;

        std::terminate();
    }
}