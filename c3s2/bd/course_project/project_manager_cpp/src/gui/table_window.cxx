#include "table_window.hxx"
#include "../models/attachment.hxx"
#include "../models/comment.hxx"
#include <iostream>

void TableWindow::draw()
{
    if (IsKeyDown(KEY_SPACE))
    {
        should_update_users = true;
        should_update_roles = true;
        should_update_projects = true;
        should_update_projects_details = true;
        should_update_projects_statuses = true;
    }

    if (!visible && table_type == TableWindowType::None)
    {
        GuiLabel(Rectangle{x + width / 2 - 50, y + height / 2 - 20, 200, 20}, "Please, choose some table.");

        return;
    }

    Window::draw();

    switch (table_type)
    {
    case TableWindowType::None:
    {
        break;
    }
    case TableWindowType::Users:
    {
        user_draw();

        break;
    }
    case TableWindowType::Roles:
    {
        role_draw();

        break;
    }
    case TableWindowType::Projects:
    {
        project_draw();

        break;
    }
    }
}

void TableWindow::user_draw()
{
    if (should_update_users)
    {
        users = project_manager->get_all_entities<User>();

        should_update_users = false;
    }

    if (should_update_roles)
    {
        roles = project_manager->get_all_entities<Role>();

        should_update_roles = false;
    }

    static int user_selected = 0;
    static int user_scroll = 0;

    std::string users_render;
    for (const auto& user : users)
    {
        users_render += std::format("id: {}\tname: {}\t email: {}\n", user->id, user->name, user->email);
    }

    std::string roles_render;
    for (const auto& role : roles)
    {
        roles_render += std::format("id: {}\t name: {}\t desc: {}\n", role->id, role->name, role->description);
    }

    GuiGroupBox(Rectangle{x + 10, y + 10, width - 20, 50}, "Method");

    float button_y = 20;
    float button_x = 20;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        };

        static bool editing_name = false;
        static bool editing_email = false;
        static bool editing_password = false;

        float button_create_window_y = 60;
        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Name");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_user_name, 32, editing_name);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_name = true;

                editing_email = false;
                editing_password = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Email");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_user_email, 32, editing_email);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_email = true;

                editing_name = false;
                editing_password = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Password");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_user_password, 32, editing_password);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_password = true;

                editing_name = false;
                editing_email = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Role");

        button_create_window_y += 30;

        static int role_selected = -1;
        static int role_scroll = 0;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100}, roles_render.c_str(), &role_scroll, &role_selected);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Create"))
        {
            if (role_selected == -1 || role_selected >= (int)roles.size())
            {
                return;
            }

            if (editing_name && editing_email && editing_password)
            {
                editing_name = false;
                editing_email = false;
                editing_password = false;
            }

            auto user = User(create_user_name, create_user_email, create_user_password);
            user.assign_role(*roles[role_selected]);

            project_manager->create_model(user);
            should_update_users = true;
        }

        return;
    }

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete") || delete_window)
    {
        delete_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Delete"))
        {
            delete_window = false;
        }

        static int user_scroll_delete = 0;
        static int user_selected_delete = -1;

        GuiListView(Rectangle{60, y + 100, 800 - 80 - 40, 300}, users_render.c_str(), &user_scroll_delete, &user_selected_delete);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Delete"))
        {
            if (user_selected_delete == -1 || user_selected_delete >= (int)users.size())
            {
                return;
            }

            project_manager->forget_sql(
                "DELETE FROM " + Comment::s_table_name() + " where fk_author_id = '" + users[user_selected_delete]->id + "';");

            project_manager->forget_sql(
                "DELETE FROM " + Attachment::s_table_name() + " where fk_author_id = '" + users[user_selected_delete]->id + "';");

            project_manager->delete_entity_by_id<User>(users[user_selected_delete]->id);
            should_update_users = true;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, users_render.c_str(), &user_scroll, &user_selected);
}

void TableWindow::role_draw()
{
    if (should_update_roles)
    {
        roles = project_manager->get_all_entities<Role>();

        should_update_roles = false;
    }

    static int role_selected = -1;
    static int role_scroll = 0;

    std::string roles_render;
    for (const auto& role : roles)
    {
        roles_render += std::format("id: {}\t name: {}\t desc: {}\n", role->id, role->name, role->description);
    }

    GuiGroupBox(Rectangle{x + 10, y + 10, width - 20, 50}, "Method");

    float button_y = 20;
    float button_x = 20;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        };

        float button_create_window_y = 100;

        static bool editing_name = false;
        static bool editing_description = false;
        static bool editing_priority = false;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Name");

        button_create_window_y += 40;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_role_name, 32, editing_name);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_name = true;

                editing_description = false;
                editing_priority = false;
            }
        }

        button_create_window_y += 40;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Description");

        button_create_window_y += 40;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_role_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;

                editing_name = false;
                editing_priority = false;
            }
        }

        button_create_window_y += 40;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Priority");

        button_create_window_y += 40;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_role_priority, 32, editing_priority);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_priority = true;

                editing_name = false;
                editing_description = false;
            }
        }

        button_create_window_y += 40;

        if (GuiButton(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            if (editing_name && editing_description && editing_priority)
            {
                editing_name = false;
                editing_description = false;
                editing_priority = false;
            }

            auto role = Role(create_role_name, create_role_description, std::stoi(create_role_priority));
            project_manager->create_model(role);
            should_update_roles = true;
        }

        return;
    }

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete") || delete_window)
    {
        delete_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Delete"))
        {
            delete_window = false;
        }

        static int role_scroll_delete = 0;
        static int role_selected_delete = -1;

        GuiListView(Rectangle{60, y + 100, 800 - 80 - 40, 300}, roles_render.c_str(), &role_scroll_delete, &role_selected_delete);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Delete"))
        {
            if (role_selected_delete == -1 || role_selected_delete >= (int)roles.size())
            {
                return;
            }

            const auto role_users = project_manager->map_sql<User>(
                "SELECT * FROM " + User::s_table_name() + " WHERE fk_role_id = '" + roles[role_selected_delete]->id + "';");

            for (const auto& user : role_users)
            {
                project_manager->forget_sql("DELETE FROM " + Comment::s_table_name() + " WHERE fk_author_id = '" + user->id + "';");
                project_manager->forget_sql("DELETE FROM " + Attachment::s_table_name() + " WHERE fk_author_id = '" + user->id + "';");
                project_manager->delete_entity_by_id<User>(user->id);
            }

            project_manager->delete_entity_by_id<Role>(roles[role_selected_delete]->id);

            should_update_roles = true;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, roles_render.c_str(), &role_scroll, &role_selected);
}

void TableWindow::project_draw()
{
    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    if (should_update_projects_details)
    {
        project_details = project_manager->get_all_entities<ProjectDetails>();

        should_update_projects_details = false;
    }

    if (should_update_projects_statuses)
    {
        project_statuses = project_manager->get_all_entities<ProjectStatus>();

        should_update_projects_statuses = false;
    }

    if (should_update_project_stages)
    {
        project_stages = project_manager->get_all_entities<ProjectStage>();

        should_update_project_stages = false;
    }

    static int project_selected = 0;
    static int project_scroll = 0;

    std::string projects_render;
    for (const auto& project : projects)
    {
        projects_render += std::format(
            "id: {}\tstage_id: {} \t status_id: {} \n", project->id, project->fk_project_stage_id, project->fk_project_status_id);
    }

    std::string project_stages_render;
    for (const auto& stage : project_stages)
    {
        project_stages_render += std::format("id: {}\t title: {}\t description: {}\n", stage->id, stage->title, stage->description);
    }

    std::string project_status_render;
    for (const auto& status : project_statuses)
    {
        project_status_render += std::format("id: {}\t title: {}\t description: {}\n", status->id, status->title, status->description);
    }

    GuiGroupBox(Rectangle{x + 10, y + 10, width - 20, 50}, "Method");

    float button_y = 20;
    float button_x = 20;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        float button_create_window_y = 100;

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Statuses");

        button_create_window_y += 30;

        static int project_status_selected = -1;
        static int project_status_scroll = 0;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100},
            project_status_render.c_str(),
            &project_status_scroll,
            &project_status_selected);

        button_create_window_y += 130;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Stages");

        button_create_window_y += 30;

        static int project_stage_selected = -1;
        static int project_stage_scroll = 0;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100},
            project_stages_render.c_str(),
            &project_stage_scroll,
            &project_stage_selected);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Create"))
        {
            if (project_status_selected == -1 || project_stage_selected == -1)
            {
                return;
            }

            if (project_status_selected >= (int)project_stages.size() || project_stage_selected >= (int)project_details.size())
            {
                return;
            }

            const auto project_stage = *project_stages[project_stage_selected];
            const auto project_status = *project_statuses[project_status_selected];

            auto project = Project();

            project.assign_project_stage(project_stage);
            project.assign_project_status(project_status);

            project_manager->create_model(project);

            should_update_projects = true;
        }

        return;
    }

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete") || delete_window)
    {
        delete_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Delete"))
        {
            delete_window = false;
        }

        static int projects_scroll_delete = 0;
        static int projects_selected_delete = -1;

        GuiListView(
            Rectangle{60, y + 100, 800 - 80 - 40, 300}, projects_render.c_str(), &projects_scroll_delete, &projects_selected_delete);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Delete"))
        {
            if (projects_selected_delete == -1 || projects_selected_delete >= (int)projects.size())
            {
                return;
            }

            project_manager->forget_sql(
                "DELETE FROM " + Project::s_table_name() + " WHERE id = '" + projects[projects_selected_delete]->id + "';");

            project_manager->delete_entity_by_id<Role>(projects[projects_selected_delete]->id);

            should_update_projects = true;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, projects_render.c_str(), &project_scroll, &project_selected);
}