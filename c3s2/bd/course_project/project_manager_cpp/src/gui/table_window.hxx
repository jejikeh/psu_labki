#pragma once

#include "../project_manager.hxx"
#include "../raygui.h"
#include "window.hxx"

enum class TableWindowType
{
    None,
    Users,
    Roles,
    Projects,
};

class TableWindow final : public Window
{
public:
    std::unique_ptr<ProjectManager> project_manager;

    TableWindowType table_type = TableWindowType::None;

    bool create_window;
    bool delete_window;

    bool should_update_users = true;
    bool should_update_roles = true;
    bool should_update_projects = true;
    bool should_update_projects_statuses = true;
    bool should_update_projects_details = true;
    bool should_update_project_stages = true;

    char* create_user_name;
    char* create_user_email;
    char* create_user_password;

    char* create_role_name;
    char* create_role_description;
    char* create_role_priority;

    std::vector<std::shared_ptr<User>> users;
    std::vector<std::shared_ptr<Role>> roles;
    std::vector<std::shared_ptr<Project>> projects;
    std::vector<std::shared_ptr<ProjectStatus>> project_statuses;
    std::vector<std::shared_ptr<ProjectStage>> project_stages;
    std::vector<std::shared_ptr<ProjectDetails>> project_details;

    TableWindow(float x, float y, float width, float height) : Window(x, y, width, height, "Example Window")
    {
        create_window = false;
        delete_window = false;

        create_user_name = new char[32];
        create_user_email = new char[32];
        create_user_password = new char[32];

        create_role_name = new char[32];
        create_role_description = new char[32];
        create_role_priority = new char[32];

        project_manager = std::make_unique<ProjectManager>();
        //
        //        User user = User("admin", "admin", "admin");
        //        user.assign_role(*project_manager->get_all_entities<Role>()[0]);
        //
        //        project_manager->create_model(user);
    }

    ~TableWindow()
    {
        delete[] create_user_name;
        delete[] create_user_email;
        delete[] create_user_password;

        delete[] create_role_name;
        delete[] create_role_description;
        delete[] create_role_priority;
    }

    void set_table_type(TableWindowType type)
    {
        table_type = type;
        visible = true;

        switch (table_type)
        {
        case TableWindowType::None:
        {
            title = "";

            break;
        }
        case TableWindowType::Users:
        {
            title = "Users";

            break;
        }
        case TableWindowType::Roles:
        {
            title = "Roles";

            break;
        }
        case TableWindowType::Projects:
        {
            title = "Projects";

            break;
        }
        }
    }

    void update() override
    {
    }

    void draw() override;

    void user_draw();
    void role_draw();
    void project_draw();
};