#pragma once

#include "model.hxx"

class Task : public Model
{
public:
    std::string title;

    [[nodiscard]] static constexpr std::string s_table_name()
    {
        return "tasks";
    }
};