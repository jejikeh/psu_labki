#pragma once

#include <memory>
#include "sql_manager.hxx"
#include "models/model.hxx"

#define PROJECT_MANAGER_CONNECTION_STRING "postgres://lablab6:lablab6@localhost:5432/lablab6"

class ProjectManager
{
public:
    std::unique_ptr<SQLManager> sql_manager;

    ProjectManager();

    void init_table() const;
    void drop_table() const;

    void create_model(const Model& entity) const;

    template <class T> std::shared_ptr<T> get_entity_by_id(const T* entity) const
    {
        auto model = static_cast<const Model*>(entity);

        if (model == nullptr)
        {
            return nullptr;
        }

        const auto sql = "SELECT * FROM " + model->table_name() + " WHERE id = '" + model->id + "';";

        auto result = execute_sql(sql, false);

        if (result.empty())
        {
            return nullptr;
        }

        auto returned_model = std::make_shared<T>();
        returned_model->from_pqxx_row(result[0]);

        return returned_model;
    }

private:
    pqxx::result execute_sql(const std::string& sql, bool throw_on_error = true) const;
};
