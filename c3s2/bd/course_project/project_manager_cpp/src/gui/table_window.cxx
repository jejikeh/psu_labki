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
        should_update_projects_statuses = true;
        should_update_projects_details = true;
        should_update_project_stages = true;
        should_update_project_reports = true;
        should_update_teams = true;
        should_update_reports = true;
        should_update_tasks = true;
        should_update_task_status = true;
        should_update_task_tags = true;
        should_update_comments = true;
        should_update_file_type = true;
        should_update_attachments = true;

        should_update_get_attachment_from_user_bigger_than = true;
        should_update_get_user_roles = true;
        should_update_get_user_files = true;
        should_update_get_project_tasks = true;
        should_update_get_project_task_details = true;
        should_update_get_user_comment_counts = true;
        should_update_get_project_teams_counts = true;
        should_update_search_projects_by_title = true;
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
    case TableWindowType::ProjectDetails:
    {
        project_details_draw();

        break;
    }
    case TableWindowType::ProjectStatus:
    {
        project_status_draw();

        break;
    }
    case TableWindowType::ProjectStages:
    {
        project_stages_draw();

        break;
    }
    case TableWindowType::ProjectReports:
    {
        project_reports_draw();

        break;
    }
    case TableWindowType::Team:
    {
        team_draw();

        break;
    }
    case TableWindowType::Report:
    {
        report_draw();

        break;
    }
    case TableWindowType::Task:
    {
        task_draw();

        break;
    }
    case TableWindowType::TaskStatus:
    {
        task_status_draw();

        break;
    }
    case TableWindowType::TaskTag:
    {
        task_tag_draw();

        break;
    }
    case TableWindowType::Comment:
    {
        comment_draw();

        break;
    }
    case TableWindowType::FileType:
    {
        file_type_draw();

        break;
    }
    case TableWindowType::Attachment:
    {
        attachment_draw();

        break;
    }

    case TableWindowType::get_attachment_from_user_bigger_than:
    {
        get_attachment_from_user_bigger_than_draw();

        break;
    }

    case TableWindowType::get_user_roles:
    {
        get_user_roles();

        break;
    }

    case TableWindowType::get_user_files:
    {
        get_user_files();

        break;
    }

    case TableWindowType::get_project_tasks:
    {
        get_project_tasks();

        break;
    }

    case TableWindowType::get_project_task_details:
    {
        get_project_task_details();

        break;
    }

    case TableWindowType::get_user_comment_counts:
    {
        get_user_comment_counts();

        break;
    }

    case TableWindowType::get_project_teams_counts:
    {
        get_project_teams_counts();

        break;
    }

    case TableWindowType::search_projects_by_title:
    {
        search_projects_by_title_draw();

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

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    float button_y = 25;
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

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        static int role_selected = -1;
        static int role_scroll = 0;

        if (user_selected != -1 && user_selected < (int)users.size())
        {
            if (role_selected != -1)
            {
                goto SKIP_CHAR_INIT;
            }

            const auto selected_user = users[user_selected];

            create_user_name = selected_user->name.data();
            create_user_email = selected_user->email.data();
            create_user_password = selected_user->password.data();
            const auto it = std::find_if(
                roles.begin(), roles.end(), [selected_user](const auto& role) { return role->id == selected_user->fk_role_id; });

            if (it != roles.end())
            {
                role_selected = it - roles.begin();
            }
        }

    SKIP_CHAR_INIT:

        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        static bool editing_name = false;
        static bool editing_email = false;
        static bool editing_password = false;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;

            role_selected = -1;

            editing_name = false;
            editing_email = false;
            editing_password = false;
        }

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

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Roles");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100}, roles_render.c_str(), &role_scroll, &role_selected);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Update"))
        {
            if (user_selected == -1 || user_selected >= (int)users.size())
            {
                return;
            }

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

            project_manager->forget_sql("UPDATE " + User::s_table_name() + " SET name = '" + create_user_name + "', email = '" +
                                        create_user_email + "', password = '" + create_user_password + "', fk_role_id = '" +
                                        roles[role_selected]->id + "' where id = '" + users[user_selected]->id + "';");

            should_update_users = true;
            role_selected = -1;
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

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    float button_y = 25;
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

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        static bool editing_name = false;
        static bool editing_description = false;
        static bool editing_priority = false;

        if (role_selected != -1 && role_selected < (int)roles.size())
        {
            const auto role = roles[role_selected];

            create_role_name = role->name.data();
            create_role_description = role->description.data();
            create_role_priority = std::to_string(role->priority).data();
        }

        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;

            role_selected = -1;

            editing_name = false;
            editing_description = false;
            editing_priority = false;
        }

        float button_create_window_y = 100;

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

        if (GuiButton(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            if (role_selected == -1 || role_selected >= (int)roles.size())
            {
                return;
            }

            if (editing_name && editing_description && editing_priority)
            {
                editing_name = false;
                editing_description = false;
                editing_priority = false;
            }

            //            auto role = Role(create_role_name, create_role_description, std::stoi(create_role_priority));
            //            project_manager->create_model(role);

            project_manager->forget_sql("UPDATE " + Role::s_table_name() + " SET name = '" + create_role_name + "', description = '" +
                                        create_role_description + "', priority = '" + create_role_priority + "' WHERE id = '" +
                                        roles[role_selected]->id + "';");

            should_update_roles = true;
            role_selected = -1;
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

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    float button_y = 25;
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

            if (project_status_selected >= (int)project_statuses.size() || project_stage_selected >= (int)project_stages.size())
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

            project_manager->forget_sql("DELETE FROM " + ProjectDetails::s_table_name() + " WHERE fk_project_id = '" +
                                        projects[projects_selected_delete]->id + "';");

            project_manager->forget_sql(
                "DELETE FROM " + Project::s_table_name() + " WHERE id = '" + projects[projects_selected_delete]->id + "';");

            project_manager->delete_entity_by_id<Role>(projects[projects_selected_delete]->id);

            should_update_projects = true;
            should_update_projects_details = true;
        }

        return;
    }

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        static int project_status_selected = -1;
        static int project_status_scroll = 0;

        static int project_stage_selected = -1;
        static int project_stage_scroll = 0;

        if (project_selected != -1 && project_selected < (int)projects.size())
        {
            if (project_status_selected != -1 && project_stage_selected != -1)
            {
                goto END_OF_BLOCK;
            }

            const auto project = projects[project_selected];

            const auto it_status = std::find_if(project_statuses.begin(),
                project_statuses.end(),
                [&](const auto& status) { return status->id == project->fk_project_status_id; });
            const auto it_stage = std::find_if(
                project_stages.begin(), project_stages.end(), [&](const auto& stage) { return stage->id == project->fk_project_stage_id; });

            project_status_selected = std::distance(project_statuses.begin(), it_status);
            project_stage_selected = std::distance(project_stages.begin(), it_stage);
        }

    END_OF_BLOCK:

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        float button_create_window_y = 100;

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Statuses");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100},
            project_status_render.c_str(),
            &project_status_scroll,
            &project_status_selected);

        button_create_window_y += 130;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Stages");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100},
            project_stages_render.c_str(),
            &project_stage_scroll,
            &project_stage_selected);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Update"))
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

            project_manager->forget_sql("UPDATE " + Project::s_table_name() + " SET fk_project_status_id = '" + project_status.id +
                                        "', fk_project_stage_id = '" + project_stage.id + "' WHERE id = '" +
                                        projects[project_selected]->id + "';");

            should_update_projects = true;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, projects_render.c_str(), &project_scroll, &project_selected);
}

void TableWindow::project_details_draw()
{
    if (should_update_projects_details)
    {
        project_details = project_manager->get_all_entities<ProjectDetails>();

        strcpy(create_project_details_title, "");
        strcpy(create_project_details_description, "");
        strcpy(create_project_details_end_date, "");

        should_update_projects_details = false;
    }

    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    std::string project_details_render;
    for (const auto& project_detail : project_details)
    {
        project_details_render += std::format("id: {}\tname: {}\t desc: {}\t created_at: {}\n",
            project_detail->id,
            project_detail->title,
            project_detail->description,
            project_detail->created_at);
    }

    std::string project_render;
    for (const auto& project : projects)
    {
        project_render += std::format(
            "id: {}\t stage_id: {}\t status_id: {} \n", project->id, project->fk_project_stage_id, project->fk_project_status_id);
    }

    static int project_details_selected = -1;
    static int project_details_scroll = 0;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    float button_x = 20;
    float button_y = 25;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        static bool editing_title = false;
        static bool editing_description = false;
        static bool editing_created_at = true;

        static int project_details_scroll_created = -1;
        static int project_details_selected_created = 0;

        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        float button_create_window_y = 60;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Title");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, create_project_details_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_LEFT_BUTTON))
            {
                editing_title = true;

                editing_description = false;
                editing_created_at = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Description");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_details_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;

                editing_title = false;
                editing_created_at = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Created at");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_details_end_date, 32, editing_created_at);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_LEFT_BUTTON))
            {
                editing_created_at = true;

                editing_title = false;
                editing_description = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Project");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 40 - 80, 150},
            project_render.c_str(),
            &project_details_scroll_created,
            &project_details_selected_created);

        button_create_window_y += 150;

        if (GuiButton(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Create"))
        {
            if (project_details_selected_created == -1 || project_details_selected_created >= (int)projects.size())
            {
                return;
            }

            editing_created_at = false;
            editing_title = false;
            editing_description = false;

            auto new_project_details =
                ProjectDetails(create_project_details_title, create_project_details_description, create_project_details_end_date);
            new_project_details.assign_project(*projects[project_details_selected_created]);

            project_manager->create_model(new_project_details);

            should_update_projects_details = true;
            project_details_selected_created = -1;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete") || delete_window)
    {
        delete_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Delete"))
        {
            delete_window = false;
        }

        static int projects_details_scroll_delete = 0;
        static int projects_details_selected_delete = -1;

        GuiListView(Rectangle{60, y + 100, 800 - 80 - 40, 300},
            project_details_render.c_str(),
            &projects_details_scroll_delete,
            &projects_details_selected_delete);

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Delete"))
        {
            if (projects_details_selected_delete == -1 || projects_details_selected_delete >= (int)project_details.size())
            {
                return;
            }

            project_manager->delete_entity_by_id<ProjectDetails>(project_details[projects_details_selected_delete]->id);
            should_update_projects_details = true;
        }

        return;
    }

    button_x += 120;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        static bool editing_title = false;
        static bool editing_description = false;
        static bool editing_end_date = false;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        static int project_scroll = 0;
        static int project_selected = -1;

        if (project_details_selected != -1 && project_details_selected < (int)project_details.size())
        {
            const auto p = project_details[project_details_selected];

            create_project_details_title = p->title.data();
            create_project_details_description = p->description.data();
            create_project_details_end_date = p->created_at.data();
        }

        float button_create_window_y = 100;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Title");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_details_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_title = true;

                editing_description = false;
                editing_end_date = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Description");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_details_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;

                editing_title = false;
                editing_end_date = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "End Date");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_details_end_date, 32, editing_end_date);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_end_date = true;

                editing_description = false;
                editing_title = false;
            }
        }

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Update"))
        {
            if (project_details_selected == -1 || project_details_selected >= (int)project_details.size())
            {
                return;
            }

            editing_title = false;
            editing_description = false;
            editing_end_date = false;

            const auto sql = std::format("UPDATE project_details SET title = '{}', description = '{}', created_at = '{}' WHERE id = '{}'",
                create_project_details_title,
                create_project_details_description,
                create_project_details_end_date,
                project_details[project_details_selected]->id);

            project_manager->forget_sql(sql);

            should_update_projects_details = true;

            update_window = false;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170},
        project_details_render.c_str(),
        &project_details_scroll,
        &project_details_selected);
}

void TableWindow::project_status_draw()
{
    if (should_update_projects_statuses)
    {
        project_statuses = project_manager->get_all_entities<ProjectStatus>();

        should_update_projects_statuses = false;
    }

    if (should_update_project_reports)
    {
        project_reports = project_manager->get_all_entities<ProjectReports>();

        should_update_project_reports = false;
    }

    if (should_update_teams)
    {
        teams = project_manager->get_all_entities<Team>();

        should_update_teams = false;
    }

    std::string project_status_render;
    for (const auto& project_status : project_statuses)
    {
        project_status_render +=
            std::format("id: {}\t title: {}\t desc: {}\n", project_status->id, project_status->title, project_status->description);
    }

    static int project_status_scroll = 0;
    static int project_status_selected = 0;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    float button_x = 20;
    float button_y = 25;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        static bool editing_title = false;
        static bool editing_description = false;

        float button_create_window_y = 60;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Title");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_status_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_title = true;

                editing_description = false;
            }
        }

        button_create_window_y += 30;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, "Description");

        button_create_window_y += 30;

        GuiTextBox(Rectangle{60, button_create_window_y, 800 - 40 - 80, 30}, create_project_status_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_create_window_y &&
            GetMousePosition().y < button_create_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;

                editing_title = false;
            }
        }

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Create"))
        {
            editing_title = false;
            editing_description = false;

            auto status = ProjectStatus(create_project_status_title, create_project_status_description);

            project_manager->create_model(status);

            should_update_projects_statuses = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (project_status_selected != -1 || project_status_selected <= (int)project_statuses.size())
        {
            const auto& project_status = project_statuses[project_status_selected];

            create_project_status_title = project_status->title.data();
            create_project_status_description = project_status->description.data();
        }

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        static bool editing_title = false;
        static bool editing_description = false;

        float button_update_window_y = 60;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 40 - 80, 30}, "Title");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 40 - 80, 30}, create_project_status_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_title = true;
                editing_description = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 40 - 80, 30}, "Description");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 40 - 80, 30}, create_project_status_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 40 - 80 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;
                editing_title = false;
            }
        }

        button_update_window_y += 30;

        if (GuiButton(Rectangle{60, 600 - 80, 800 - 80 - 40, 30}, "Update"))
        {
            editing_title = false;
            editing_description = false;

            project_manager->forget_sql(std::string("UPDATE project_statuses SET title = '") + create_project_status_title +
                                        "', description = '" + create_project_status_description + "' WHERE id = '" +
                                        (project_statuses[project_status_selected]->id) + "';");

            should_update_projects_statuses = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (project_status_selected != -1 && project_status_selected <= (int)project_statuses.size())
        {
            const auto& project_status = project_statuses[project_status_selected];

            const auto projects_statusesx =
                project_manager->map_sql<Project>("SELECT * FROM projects WHERE fk_project_status_id = '" + (project_status->id) + "';");

            project_manager->forget_sql(std::string("DELETE FROM project_details WHERE fk_project_id = '") + (project_status->id) + "';");

            const auto teamsx =
                project_manager->map_sql<Team>(std::string("SELECT * FROM teams WHERE fk_project_id = '") + (project_status->id) + "';");

            for (const auto& team : teamsx)
            {
                const auto tasksx =
                    project_manager->map_sql<Task>(std::string("SELECT * FROM tasks WHERE fk_team_id = '") + (team->id) + "';");

                for (const auto& task : tasksx)
                {
                    project_manager->forget_sql(std::string("DELETE FROM task_tags WHERE fk_task_id = '") + (task->id) + "';");
                }

                project_manager->forget_sql(std::string("DELETE FROM tasks WHERE fk_team_id = '") + (team->id) + "';");
            }

            project_manager->forget_sql(std::string("DELETE FROM teams WHERE fk_project_id = '") + (project_status->id) + "';");

            project_manager->forget_sql("DELETE FROM projects WHERE fk_project_status_id = '" + (project_status->id) + "';");

            project_manager->delete_entity_by_id<ProjectStatus>(project_status->id);

            should_update_projects_statuses = true;
        }
    }

    GuiListView(
        Rectangle{x + 10, y + 100, width - 20, 600 - 170}, project_status_render.c_str(), &project_status_scroll, &project_status_selected);
}

void TableWindow::project_stages_draw()
{
    if (should_update_project_stages)
    {
        project_stages = project_manager->get_all_entities<ProjectStage>();

        should_update_project_stages = false;
    }

    std::string project_stages_render;
    for (const auto& project_stage : project_stages)
    {
        project_stages_render += std::format("id: {}\t title: {} \t start_date: {} \t end_date: {} \n",
            project_stage->id,
            project_stage->title,
            project_stage->start_date,
            project_stage->end_date);
    }

    static int project_stage_selected = -1;
    static int project_stage_scroll = 0;

    float button_x = 20;
    float button_y = 25;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        static bool editing_title = false;
        static bool editing_description = false;
        static bool editing_start_date = false;
        static bool editing_end_date = false;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        create_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        float button_update_window_y = 100;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Title");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_title = true;

                editing_description = false;
                editing_start_date = false;
                editing_end_date = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Description");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;

                editing_title = false;
                editing_start_date = false;
                editing_end_date = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Start date");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_start_date, 32, editing_start_date);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_start_date = true;

                editing_title = false;
                editing_description = false;
                editing_end_date = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "End date");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_end_date, 32, editing_end_date);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_end_date = true;

                editing_title = false;
                editing_description = false;
                editing_start_date = false;
            }
        }

        button_update_window_y += 100;

        if (GuiButton(Rectangle{60, button_update_window_y, 800 - 40 - 80, 30}, "Create"))
        {
            editing_end_date = false;
            editing_title = false;
            editing_description = false;
            editing_start_date = false;

            auto project_stage = ProjectStage(create_project_stage_title,
                create_project_stage_description,
                create_project_stage_start_date,
                create_project_stage_end_date);

            project_manager->create_model(project_stage);

            should_update_project_stages = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        static bool editing_title = false;
        static bool editing_description = false;
        static bool editing_start_date = false;
        static bool editing_end_date = false;

        update_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        if (project_stage_selected != -1 && project_stage_selected < (int)project_stages.size())
        {
            auto project_stage = project_stages[project_stage_selected];

            create_project_stage_title = project_stage->title.data();
            create_project_stage_description = project_stage->description.data();
            create_project_stage_end_date = project_stage->end_date.data();
            create_project_stage_start_date = project_stage->start_date.data();
        }

        float button_update_window_y = 100;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Title");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_title = true;

                editing_description = false;
                editing_start_date = false;
                editing_end_date = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Description");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_description = true;

                editing_title = false;
                editing_start_date = false;
                editing_end_date = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Start date");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_start_date, 32, editing_start_date);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_start_date = true;

                editing_title = false;
                editing_description = false;
                editing_end_date = false;
            }
        }

        button_update_window_y += 30;

        GuiLabel(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "End date");

        button_update_window_y += 30;

        GuiTextBox(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, create_project_stage_end_date, 32, editing_end_date);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > button_update_window_y &&
            GetMousePosition().y < button_update_window_y + 30)
        {
            if (IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
            {
                editing_end_date = true;

                editing_title = false;
                editing_description = false;
                editing_start_date = false;
            }
        }

        button_update_window_y += 100;

        if (GuiButton(Rectangle{60, button_update_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_title = false;
            editing_description = false;
            editing_start_date = false;
            editing_end_date = false;

            project_manager->forget_sql(std::format(
                "UPDATE project_stages SET title = '{}', description = '{}', start_date = '{}', end_date = '{}' WHERE id = '{}'",
                std::string(create_project_stage_title),
                std::string(create_project_stage_description),
                std::string(create_project_stage_start_date),
                std::string(create_project_stage_end_date),
                project_stages[project_stage_selected]->id));
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
    }

    GuiListView(
        Rectangle{x + 10, y + 100, width - 20, 600 - 170}, project_stages_render.c_str(), &project_stage_selected, &project_stage_scroll);
}

void TableWindow::project_reports_draw()
{
    if (should_update_project_reports)
    {
        project_reports = project_manager->get_all_entities<ProjectReports>();

        should_update_project_reports = false;
    }

    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    if (should_update_reports)
    {
        reports = project_manager->get_all_entities<Report>();

        should_update_reports = false;
    }

    static int project_report_selected = -1;
    static int project_report_scroll = 0;

    std::string reports_render;
    for (const auto& pr : reports)
    {
        reports_render += std::format("id: {}\t value: {}\t desc: {}\n", pr->id, pr->value, pr->description);
    }

    std::string project_reports_render;
    for (const auto& pr : project_reports)
    {
        project_reports_render += std::format("id: {}\t project_id: {} \t report_id: {}\n", pr->id, pr->fk_project_id, pr->fk_report_id);
    }

    std::string projects_render;
    for (const auto& project : projects)
    {
        projects_render += std::format(
            "id: {}\tstage_id: {} \t status_id: {} \n", project->id, project->fk_project_stage_id, project->fk_project_status_id);
    }

    float button_x = 20;
    float button_y = 25;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        static int project_selected = -1;
        static int project_scroll = 0;

        static int report_selected = -1;
        static int report_scroll = 0;

        float button_create_window_y = 100;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Project");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100}, projects_render.c_str(), &project_scroll, &project_selected);

        button_create_window_y += 100;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Report");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100}, reports_render.c_str(), &report_scroll, &report_selected);

        button_create_window_y += 100;

        if (GuiButton(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            if (project_selected == -1 || report_selected == -1)
            {
                return;
            }

            if (project_selected >= (int)projects.size() || report_selected >= (int)reports.size())
            {
                return;
            }

            auto project_report = ProjectReports();
            project_report.assign_report_and_project(*reports[report_selected], *projects[project_selected]);

            project_manager->create_model(project_report);

            should_update_project_reports = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        static int project_selected = -1;
        static int project_scroll = 0;

        static int report_selected = -1;
        static int report_scroll = 0;

        if (project_report_selected == -1 || project_report_selected >= (int)project_reports.size())
        {
            return;
        }

        if (project_selected == -1 || report_selected == -1)
        {
            auto selected_project_in_ui = project_reports[project_report_selected];

            const auto project_it = std::find_if(projects.begin(),
                projects.end(),
                [&selected_project_in_ui](const auto& project) { return project->id == selected_project_in_ui->fk_project_id; });

            const auto report_it = std::find_if(reports.begin(),
                reports.end(),
                [&selected_project_in_ui](const auto& report) { return report->id == selected_project_in_ui->fk_report_id; });

            if (project_it == projects.end() || report_it == reports.end())
            {
                return;
            }

            project_selected = std::distance(projects.begin(), project_it);
            report_selected = std::distance(reports.begin(), report_it);
        }

        float button_create_window_y = 100;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Project");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100}, projects_render.c_str(), &project_scroll, &project_selected);

        button_create_window_y += 100;

        GuiLabel(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Report");

        button_create_window_y += 30;

        GuiListView(Rectangle{60, button_create_window_y, 800 - 80 - 40, 100}, reports_render.c_str(), &report_scroll, &report_selected);

        button_create_window_y += 100;

        if (GuiButton(Rectangle{60, button_create_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            if (project_selected == -1 || report_selected == -1)
            {
                return;
            }

            if (project_selected >= (int)projects.size() || report_selected >= (int)reports.size())
            {
                return;
            }

            project_manager->forget_sql(std::format("UPDATE project_reports SET fk_project_id = '{}', fk_report_id = '{}' WHERE id = '{}'",
                projects[project_selected]->id,
                reports[report_selected]->id,
                project_reports[project_report_selected]->id));

            should_update_project_reports = true;

            report_selected = -1;
            project_selected = -1;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (project_report_selected == -1 || project_report_selected >= (int)project_reports.size())
        {
            return;
        }

        project_manager->forget_sql(
            std::format("DELETE FROM project_reports WHERE id = '{}'", project_reports[project_report_selected]->id));

        should_update_project_reports = true;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170},
        project_reports_render.c_str(),
        &project_report_scroll,
        &project_report_selected);
}

void TableWindow::team_draw()
{
    if (should_update_teams)
    {
        teams = project_manager->get_all_entities<Team>();

        should_update_teams = false;
    }

    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    static int team_selected = -1;
    static int team_scroll = 0;

    std::string teams_render;
    for (const auto& t : teams)
    {
        teams_render += std::format("id: {} \t description: {} \t, project_id: {} \n", t->id, t->description, t->fk_project_id);
    }

    std::string projects_render;
    for (const auto& project : projects)
    {
        projects_render += std::format(
            "id: {}\tstage_id: {} \t status_id: {} \n", project->id, project->fk_project_stage_id, project->fk_project_status_id);
    }

    float button_x = 20;
    float button_y = 25;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        static bool editing_description = false;

        create_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_team_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Project ID");

        create_button_window_y += 30;

        static int project_selected = -1;
        static int project_scroll = 0;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, projects_render.c_str(), &project_scroll, &project_selected);

        create_button_window_y += 130;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            if (project_selected == -1)
            {
                return;
            }

            auto team = Team(create_team_description);
            team.assign_project(*projects[project_selected]);

            project_manager->create_model(team);

            should_update_teams = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (team_selected == -1 || team_selected >= (int)teams.size())
        {
            return;
        }

        project_manager->forget_sql(std::format("DELETE FROM teams WHERE id = '{}'", teams[team_selected]->id));

        should_update_teams = true;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        static bool editing_description = false;
        static int project_selected = -1;
        static int project_scroll = 0;

        update_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        if (team_selected != -1 && team_selected < (int)teams.size() && project_selected == -1)
        {
            const auto team_selected_in_ui = teams[team_selected];

            create_team_description = team_selected_in_ui->description.data();

            const auto project_it = std::find_if(projects.begin(),
                projects.end(),
                [&team_selected_in_ui](const auto& prj) { return prj->id == team_selected_in_ui->fk_project_id; });

            if (project_it != projects.end())
            {
                project_selected = std::distance(projects.begin(), project_it);
            }
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_team_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Project ID");

        create_button_window_y += 30;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, projects_render.c_str(), &project_scroll, &project_selected);

        create_button_window_y += 130;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            if (project_selected == -1)
            {
                return;
            }

            const auto proj = projects[project_selected];

            project_manager->forget_sql(std::format("UPDATE teams SET description = '{}', fk_project_id = '{}' WHERE id = '{}'",
                create_team_description,
                proj->id,
                teams[team_selected]->id));

            should_update_teams = true;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, teams_render.c_str(), &team_scroll, &team_selected);
}

void TableWindow::report_draw()
{
    if (should_update_reports)
    {
        reports = project_manager->get_all_entities<Report>();

        should_update_reports = false;
    }

    std::string reports_render;
    for (const auto& pr : reports)
    {
        reports_render += std::format("id: {}\t value: {}\t desc: {}\n", pr->id, pr->value, pr->description);
    }

    float button_x = 20;
    float button_y = 25;

    static int report_selected = -1;
    static int report_scroll = 0;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        static bool editing_value = false;
        static bool editing_description = false;

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Value");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_report_value, 32, editing_value);
        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_value = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_report_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_value = false;
            }
        }

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            editing_value = false;
            editing_description = false;

            auto report = Report(std::atoi(create_report_value), std::string(create_report_description));

            project_manager->create_model(report);

            should_update_reports = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (report_selected == -1)
        {
            return;
        }

        project_manager->forget_sql(std::format("DELETE from project_reports WHERE fk_report_id = '{}'", reports[report_selected]->id));
        project_manager->forget_sql(std::format("DELETE FROM reports WHERE id = '{}'", reports[report_selected]->id));

        should_update_reports = true;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        static int selected_int_prev = -1;
        static bool set_value = false;
        static bool editing_value = false;
        static bool editing_description = false;

        if (selected_int_prev != report_selected)
        {
            set_value = false;
        }

        if (report_selected != -1 && report_selected < (int)reports.size() && !set_value)
        {
            set_value = true;

            selected_int_prev = report_selected;

            std::strcpy(create_report_value, std::to_string(reports[report_selected]->value).data());
            create_report_description = reports[report_selected]->description.data();
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Value");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_report_value, 32, editing_value);
        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_value = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_report_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_value = false;
            }
        }

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_value = false;
            editing_description = false;

            project_manager->forget_sql(std::format("UPDATE reports SET value = '{}', description = '{}' WHERE id = '{}'",
                create_report_value,
                create_report_description,
                reports[report_selected]->id));

            should_update_reports = true;

            set_value = false;

            std::strcpy(create_report_value, "");
            std::strcpy(create_report_description, "");

            selected_int_prev = -1;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, reports_render.c_str(), &report_scroll, &report_selected);
}

void TableWindow::task_draw()
{
    if (should_update_tasks)
    {
        tasks = project_manager->get_all_entities<Task>();

        should_update_tasks = false;
    }

    if (should_update_teams)
    {
        teams = project_manager->get_all_entities<Team>();

        should_update_teams = false;
    }

    if (should_update_task_status)
    {
        task_statuses = project_manager->get_all_entities<TaskStatus>();

        should_update_task_status = false;
    }

    std::string task_render;
    for (const auto& task : tasks)
    {
        task_render += std::format("id: {}\t title: {} \t description: {}\n", task->id, task->title, task->description);
    }

    std::string team_render;
    for (const auto& team : teams)
    {
        team_render += std::format("id: {}\t description: {}\n", team->id, team->description);
    }

    std::string task_status_render;
    for (const auto& task_status : task_statuses)
    {
        task_status_render += std::format("id: {}\t description: {}\n", task_status->id, task_status->description);
    }

    float button_x = 20;
    float button_y = 25;

    static int task_selected = -1;
    static int task_scroll = 0;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        static bool editing_title = false;
        static bool editing_description = false;
        static int selected_team = -1;
        static int scroll_team = 0;
        static int selected_task_status = -1;
        static int scroll_task_status = 0;

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Title");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_title = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_title = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Team");

        GuiListView(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 100}, team_render.c_str(), &scroll_team, &selected_team);

        create_button_window_y += 120;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Task Status");

        create_button_window_y += 30;

        GuiListView(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 100},
            task_status_render.c_str(),
            &scroll_task_status,
            &selected_task_status);

        create_button_window_y += 130;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            editing_title = false;
            editing_description = false;

            if (selected_team == -1 || selected_task_status == -1)
            {
                return;
            }

            if (selected_team >= (int)teams.size() || selected_task_status >= (int)task_statuses.size())
            {
                return;
            }

            auto task = Task(std::string(create_task_title), std::string(create_task_description));
            task.assign_team(*teams[selected_team]);
            task.assign_task_status(*task_statuses[selected_task_status]);

            project_manager->create_model(task);

            should_update_tasks = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        static bool editing_title = false;
        static bool editing_description = false;
        static int selected_team = -1;
        static int scroll_team = 0;
        static int selected_task_status = -1;
        static int scroll_task_status = 0;

        if (selected_team == -1 && (task_selected != -1 && (int)tasks.size() > 0))
        {
            auto task = tasks[task_selected];

            std::strcpy(create_task_title, task->title.c_str());
            std::strcpy(create_task_description, task->description.c_str());

            const auto& team_d =
                std::find_if(teams.begin(), teams.end(), [task](const auto& team) { return team->id == task->fk_team_id; });

            const auto& task_status_d = std::find_if(task_statuses.begin(),
                task_statuses.end(),
                [task](const auto& task_status) { return task_status->id == task->fk_task_status_id; });

            selected_team = std::distance(teams.begin(), team_d);
            selected_task_status = std::distance(task_statuses.begin(), task_status_d);
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Title");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_title = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_title = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Team");

        GuiListView(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 100}, team_render.c_str(), &scroll_team, &selected_team);

        create_button_window_y += 120;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Task Status");

        create_button_window_y += 30;

        GuiListView(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 100},
            task_status_render.c_str(),
            &scroll_task_status,
            &selected_task_status);

        create_button_window_y += 130;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_title = false;
            editing_description = false;

            if (selected_team == -1 || selected_task_status == -1)
            {
                return;
            }

            if (selected_team >= (int)teams.size() || selected_task_status >= (int)task_statuses.size())
            {
                return;
            }

            project_manager->forget_sql(std::format(
                "UPDATE tasks SET title = '{}', description = '{}', fk_team_id = '{}', fk_task_status_id = '{}' WHERE id = '{}'",
                create_task_title,
                create_task_description,
                teams[selected_team]->id,
                task_statuses[selected_task_status]->id,
                tasks[task_selected]->id));

            should_update_tasks = true;

            task_selected = -1;
            selected_team = -1;
            selected_task_status = -1;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (task_selected == -1)
        {
            return;
        }

        auto task = tasks[task_selected];

        project_manager->forget_sql(std::format("DELETE FROM task_tags WHERE fk_task_id = '{}'", task->id));
        project_manager->forget_sql(std::format("DELETE FROM tasks WHERE id = '{}'", task->id));

        should_update_tasks = true;
    }

    GuiListView(Rectangle{x + 10, y + 80, width - 20, height - 120}, task_render.c_str(), &task_scroll, &task_selected);
}

void TableWindow::task_status_draw()
{
    if (should_update_task_status)
    {
        task_statuses = project_manager->get_all_entities<TaskStatus>();

        should_update_task_status = false;
    }

    std::string task_status_render;
    for (const auto& task_status : task_statuses)
    {
        task_status_render +=
            std::format("id: {}\t title: {} \t description: {}\n", task_status->id, task_status->title, task_status->description);
    }

    static int task_status_scroll = 0;
    static int task_status_selected = -1;

    float button_x = 20;
    float button_y = 25;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{Rectangle{40, 40, 800 - 80, 600 - 80}}, "Create"))
        {
            create_window = false;
        }

        static bool editing_title = false;
        static bool editing_description = false;

        static bool create_task_status_stages = false;

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Title");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_status_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_title = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_status_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_title = false;
            }
        }

        create_button_window_y += 64;

        GuiCheckBox(Rectangle{60, create_button_window_y, 30, 30}, "Staging", &create_task_status_stages);

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_title = false;
            editing_description = false;

            auto task_status = TaskStatus(create_task_status_title, create_task_status_description, create_task_status_stages);

            project_manager->create_model(task_status);

            should_update_task_status = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (task_status_selected == -1)
        {
            return;
        }

        auto task_status = task_statuses[task_status_selected];

        auto tasks1 = project_manager->map_sql<Task>(std::format("SELECT * FROM tasks WHERE fk_task_status_id = '{}'", task_status->id));

        for (const auto& task : tasks1)
        {
            project_manager->forget_sql(std::format("DELETE FROM task_tags WHERE fk_task_id = '{}'", task->id));
        }

        project_manager->forget_sql(std::format("DELETE FROM tasks WHERE fk_task_status_id = '{}'", task_status->id));

        project_manager->forget_sql(std::format("DELETE FROM task_status WHERE id = '{}'", task_status->id));

        should_update_task_status = true;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{Rectangle{40, 40, 800 - 80, 600 - 80}}, "Update"))
        {
            update_window = false;
        }

        static bool editing_title = false;
        static bool editing_description = false;
        static bool create_task_status_stages = false;

        static bool p = false;

        if (task_status_selected != -1 && !p)
        {
            auto selected_task = task_statuses[task_status_selected];

            std::strcpy(create_task_status_title, selected_task->title.c_str());
            std::strcpy(create_task_status_description, selected_task->description.c_str());

            create_task_status_stages = selected_task->staging;

            p = true;
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Title");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_status_title, 32, editing_title);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_title = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_status_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_title = false;
            }
        }

        create_button_window_y += 64;

        GuiCheckBox(Rectangle{60, create_button_window_y, 30, 30}, "Staging", &create_task_status_stages);

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_title = false;
            editing_description = false;

            project_manager->forget_sql(
                std::format("UPDATE task_statuses SET title = '{}', description = '{}', staging = {} WHERE id = '{}'",
                    create_task_status_title,
                    create_task_status_description,
                    create_task_status_stages,
                    task_statuses[task_status_selected]->id));

            should_update_task_status = true;

            p = false;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, task_status_render.c_str(), &task_status_scroll, &task_status_selected);
}

void TableWindow::task_tag_draw()
{
    if (should_update_task_tags)
    {
        task_tags = project_manager->get_all_entities<TaskTag>();

        should_update_task_tags = false;
    }

    if (should_update_tasks)
    {
        tasks = project_manager->get_all_entities<Task>();

        should_update_tasks = false;
    }

    std::string tasks_render;
    for (const auto& task : tasks)
    {
        tasks_render += std::format("id: {}\t title: {} \t description: {}\n", task->id, task->title, task->description);
    }

    std::string task_tag_render;
    for (const auto& task_tag : task_tags)
    {
        task_tag_render += std::format("id: {}\t name: {}\n", task_tag->id, task_tag->tag);
    }

    static int task_tag_selected = -1;
    static int task_tag_scroll = 0;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    float button_x = 20;
    float button_y = 25;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        static bool editing_tag = false;

        static int selected_task = -1;
        static int scroll_task = 0;

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Task");

        create_button_window_y += 30;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, tasks_render.c_str(), &scroll_task, &selected_task);

        create_button_window_y += 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Tag");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_task_tag_tag, 32, editing_tag);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_tag = true;
            }
        }

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            editing_tag = false;

            auto tag = TaskTag(create_task_tag_tag);
            tag.assign_to_task(*tasks[selected_task]);

            project_manager->create_model(tag);

            should_update_task_tags = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (task_tag_selected == -1)
        {
            return;
        }

        project_manager->forget_sql(std::format("DELETE FROM task_tags WHERE id = '{}'", task_tags[task_tag_selected]->id));

        should_update_task_tags = true;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, task_tag_render.c_str(), &task_tag_scroll, &task_tag_selected);
}

void TableWindow::comment_draw()
{
    if (should_update_comments)
    {
        comments = project_manager->get_all_entities<Comment>();

        should_update_comments = false;
    }

    if (should_update_users)
    {
        users = project_manager->get_all_entities<User>();

        should_update_users = false;
    }

    std::string users_render;
    for (const auto& user : users)
    {
        users_render += std::format("id: {}\tname: {}\t email: {}\n", user->id, user->name, user->email);
    }

    std::string comments_render;
    for (const auto& comment : comments)
    {
        comments_render += std::format("id: {}\t content: {}\t created_at: {}\n", comment->id, comment->content, comment->created_at);
    }

    static int comment_selected = -1;
    static int comment_scroll = 0;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Comment");

    float button_x = 20;
    float button_y = 25;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        static bool editing_comment = false;

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Comment");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_comment_content, 32, editing_comment);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_comment = true;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "User");

        create_button_window_y += 30;

        static int user_selected = -1;
        static int user_scroll = 0;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, users_render.c_str(), &user_scroll, &user_selected);

        create_button_window_y += 130;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            if (user_selected == -1 || user_selected > (int)users.size())
            {
                return;
            }

            editing_comment = true;

            auto comment = Comment(create_comment_content);
            comment.assign_author(*users[user_selected]);

            project_manager->create_model(comment);

            should_update_comments = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (comment_selected == -1)
        {
            return;
        }

        project_manager->forget_sql(std::format("DELETE FROM comments WHERE id = '{}'", comments[comment_selected]->id));

        should_update_comments = true;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        static int user_selected = -1;
        static int user_scroll = 0;

        static bool u = false;

        if (comment_selected != -1 && !u)
        {
            auto comment_content = comments[comment_selected];

            std::strcpy(create_comment_content, comment_content->content.c_str());

            const auto userd = std::find_if(
                users.begin(), users.end(), [&comment_content](const auto& user) { return user->id == comment_content->fk_author_id; });

            user_selected = (int)std::distance(users.begin(), userd);

            u = true;
        }

        static bool editing_comment = false;

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Comment");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_comment_content, 32, editing_comment);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_comment = true;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "User");

        create_button_window_y += 30;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, users_render.c_str(), &user_scroll, &user_selected);

        create_button_window_y += 130;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            if (user_selected == -1 || user_selected > (int)users.size())
            {
                return;
            }

            editing_comment = true;

            project_manager->forget_sql(std::format("UPDATE comments SET content = '{}', fk_author_id = '{}' WHERE id = '{}'",
                create_comment_content,
                users[user_selected]->id,
                comments[comment_selected]->id));

            should_update_comments = true;
            u = false;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, comments_render.c_str(), &comment_scroll, &comment_selected);
}

void TableWindow::file_type_draw()
{
    if (should_update_file_type)
    {
        file_types = project_manager->get_all_entities<FileType>();

        should_update_file_type = false;
    }

    std::string file_types_render;
    for (const auto& file_type : file_types)
    {
        file_types_render +=
            std::format("id: {}\t extension: {} description: {}\n", file_type->id, file_type->extension, file_type->description);
    }

    static int file_type_selected = -1;
    static int file_type_scroll = 0;

    float button_x = 20;
    float button_y = 25;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        static bool editing_description = false;
        static bool editing_extension = false;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        create_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Extension");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_file_type_extension, 32, editing_extension);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_extension = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_file_type_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_extension = false;
            }
        }

        create_button_window_y += 30;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            editing_extension = false;
            editing_description = false;

            auto file_type = FileType(create_file_type_extension, create_file_type_description);

            project_manager->create_model(file_type);

            should_update_file_type = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (file_type_selected == -1 || file_type_selected > (int)file_types.size())
        {
            return;
        }

        project_manager->forget_sql(std::format("DELETE FROM file_types WHERE id = '{}'", file_types[file_type_selected]->id));

        should_update_file_type = true;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        static bool editing_description = false;
        static bool editing_extension = false;
        static bool u = false;

        DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(BLACK, 0.5f));

        update_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            update_window = false;

            u = false;
        }

        if (file_type_selected != -1 && file_type_selected < (int)file_types.size() && !u)
        {
            const auto file_type = file_types[file_type_selected];

            std::strcpy(create_file_type_extension, file_type->extension.c_str());
            std::strcpy(create_file_type_description, file_type->description.c_str());

            u = true;
        }

        float create_button_window_y = 100;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Extension");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_file_type_extension, 32, editing_extension);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_extension = true;

                editing_description = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Description");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_file_type_description, 32, editing_description);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_description = true;

                editing_extension = false;
            }
        }

        create_button_window_y += 30;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_extension = false;
            editing_description = false;

            project_manager->forget_sql(std::format("UPDATE file_types SET extension = '{}', description = '{}' WHERE id = '{}'",
                create_file_type_extension,
                create_file_type_description,
                file_types[file_type_selected]->id));

            should_update_file_type = true;
            u = false;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, file_types_render.c_str(), &file_type_scroll, &file_type_selected);
}

void TableWindow::attachment_draw()
{
    if (should_update_attachments)
    {
        attachments = project_manager->get_all_entities<Attachment>();

        should_update_attachments = false;
    }

    if (should_update_users)
    {
        users = project_manager->get_all_entities<User>();

        should_update_users = false;
    }

    if (should_update_file_type)
    {
        file_types = project_manager->get_all_entities<FileType>();

        should_update_file_type = false;
    }

    std::string attachment_render;
    for (const auto& attachment : attachments)
    {
        attachment_render += std::format("id: {}\t name: {}\n", attachment->id, attachment->file_name);
    }

    std::string user_render;
    for (const auto& user : users)
    {
        user_render += std::format("id: {}\tname: {}\t email: {}\n", user->id, user->name, user->email);
    }

    std::string file_type_render;
    for (const auto& file_type : file_types)
    {
        file_type_render +=
            std::format("id: {}\t extension: {}\t description: {}\n", file_type->id, file_type->extension, file_type->description);
    }

    static int attachment_selected = -1;
    static int attachment_scroll = 0;

    float button_x = 20;
    float button_y = 25;

    GuiGroupBox(Rectangle{x + 10, y + 15, width - 20, 50}, "Method");

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Create") || create_window)
    {
        create_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Create"))
        {
            create_window = false;
        }

        float create_button_window_y = 100;

        static bool editing_content = false;
        static bool editing_name = false;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Name");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_attachment_name, 32, editing_name);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_name = true;

                editing_content = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Content");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 70}, create_attachment_content, 32, editing_content);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_content = true;
                editing_name = false;
            }
        }

        static int user_selected = -1;
        static int user_scroll = 0;

        create_button_window_y += 60;

        GuiLabel(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 30}, "User");

        create_button_window_y += 60;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, user_render.c_str(), &user_scroll, &user_selected);

        create_button_window_y += 60;

        static int file_type_selected = -1;
        static int file_type_scroll = 0;

        GuiLabel(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 30}, "File Type");

        create_button_window_y += 60;

        GuiListView(
            Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, file_type_render.c_str(), &file_type_scroll, &file_type_selected);

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Create"))
        {
            editing_name = false;
            editing_content = false;

            if (user_selected == -1 || file_type_selected == -1)
            {
                return;
            }

            if (user_selected >= (int)users.size() || file_type_selected >= (int)file_types.size())
            {
                return;
            }

            auto attachment = Attachment(create_attachment_content, create_attachment_name, std::strlen(create_attachment_content));
            attachment.assign_author_and_file_type(*users[user_selected], *file_types[file_type_selected]);

            project_manager->create_model(attachment);

            should_update_attachments = true;
        }

        return;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Delete"))
    {
        if (attachment_selected == -1)
        {
            return;
        }

        project_manager->forget_sql(std::format("DELETE FROM attachments WHERE id = '{}'", attachments[attachment_selected]->id));

        should_update_attachments = true;
    }

    button_x += 130;

    if (GuiButton(Rectangle{x + button_x, y + button_y, 100, 30}, "Update") || update_window)
    {
        update_window = true;

        if (GuiWindowBox(Rectangle{40, 40, 800 - 80, 600 - 80}, "Update"))
        {
            update_window = false;
        }

        float create_button_window_y = 100;

        static bool editing_content = false;
        static bool editing_name = false;

        static int file_type_selected = -1;
        static int file_type_scroll = 0;

        static int user_selected = -1;
        static int user_scroll = 0;

        static bool u = false;

        if (attachment_selected == -1 || attachment_selected >= (int)attachments.size())
        {
            return;
        }

        if (!u)
        {
            u = true;

            auto attachment = attachments[attachment_selected];

            std::strcpy(create_attachment_content, attachment->file_content.c_str());
            std::strcpy(create_attachment_name, attachment->file_name.c_str());

            const auto& authorit =
                std::find_if(users.begin(), users.end(), [attachment](const auto& user) { return user->id == attachment->fk_author_id; });

            if (authorit != users.end())
            {
                user_selected = std::distance(users.begin(), authorit);
            }

            const auto& file_typeit = std::find_if(file_types.begin(),
                file_types.end(),
                [attachment](const auto& file_type) { return file_type->id == attachment->fk_file_type_id; });

            if (file_typeit != file_types.end())
            {
                file_type_selected = std::distance(file_types.begin(), file_typeit);
            }
        }

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Name");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, create_attachment_name, 32, editing_name);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_name = true;

                editing_content = false;
            }
        }

        create_button_window_y += 30;

        GuiLabel(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Content");

        create_button_window_y += 30;

        GuiTextBox(Rectangle{60, create_button_window_y, 800 - 80 - 40, 70}, create_attachment_content, 32, editing_content);

        if (GetMousePosition().x > 60 && GetMousePosition().x < 800 - 80 - 40 && GetMousePosition().y > create_button_window_y &&
            GetMousePosition().y < create_button_window_y + 30)
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
            {
                editing_content = true;
                editing_name = false;
            }
        }

        create_button_window_y += 60;

        GuiLabel(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 30}, "User");

        create_button_window_y += 60;

        GuiListView(Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, user_render.c_str(), &user_scroll, &user_selected);

        create_button_window_y += 60;

        GuiLabel(Rectangle{60, create_button_window_y + 30, 800 - 80 - 40, 30}, "File Type");

        create_button_window_y += 60;

        GuiListView(
            Rectangle{60, create_button_window_y, 800 - 80 - 40, 100}, file_type_render.c_str(), &file_type_scroll, &file_type_selected);

        create_button_window_y += 100;

        if (GuiButton(Rectangle{60, create_button_window_y, 800 - 80 - 40, 30}, "Update"))
        {
            editing_name = false;
            editing_content = false;

            if (user_selected == -1 || file_type_selected == -1)
            {
                return;
            }

            if (user_selected >= (int)users.size() || file_type_selected >= (int)file_types.size())
            {
                return;
            }

            auto user = users[user_selected];
            auto file_type = file_types[file_type_selected];

            project_manager->forget_sql(std::format(
                "UPDATE attachments SET file_name = '{}', file_content = '{}', fk_author_id = '{}', fk_file_type_id = '{}' WHERE id = '{}'",
                create_attachment_name,
                create_attachment_content,
                user->id,
                file_type->id,
                attachments[attachment_selected]->id));

            should_update_attachments = true;
        }

        return;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, attachment_render.c_str(), &attachment_scroll, &attachment_selected);
}

void TableWindow::get_attachment_from_user_bigger_than_draw()
{
    static char* attachment_size = new char[32];
    static bool editing_size = false;
    static bool updating = false;

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "Size");

    GuiTextBox(Rectangle{x + 10, y + 30, width - 20, 30}, attachment_size, 32, editing_size);

    if (GetMousePosition().x > x + 10 && GetMousePosition().x < width - 20 && GetMousePosition().y > y + 30 &&
        GetMousePosition().y < y + 60)
    {
        if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
        {
            editing_size = true;
        }
    }

    if (editing_size)
    {
        if (IsKeyPressed(KEY_ENTER))
        {
            editing_size = false;
            updating = true;
        }
    }

    if (updating)
    {
        get_attachment_from_user_bigger_than_table = project_manager->get_attachment_from_user_bigger_than(std::atoi(attachment_size));

        updating = false;
    }

    static int attachment_scroll = 0;
    static int attachment_selected = -1;

    std::string attachment_render;
    for (const auto& attachment : get_attachment_from_user_bigger_than_table)
    {
        attachment_render += std::format("id: {}\t name: {}\t size: {}\n", attachment->id, attachment->file_name, attachment->file_size);
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, attachment_render.c_str(), &attachment_scroll, &attachment_selected);
}

void TableWindow::get_user_roles()
{
    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    static int role_scroll = 0;
    static int role_selected = -1;
    static bool updating = true;

    std::string roles_render;
    for (const auto& attachment : get_user_roles_table)
    {
        roles_render += std::format("role_name: {}\t email: {}\t name: {}\n", attachment->role_name, attachment->email, attachment->name);
    }

    if (updating)
    {
        get_user_roles_table = project_manager->get_user_roles();

        updating = false;
    }

    if (IsKeyPressed(KEY_ENTER))
    {
        updating = true;
    }

    GuiListView(Rectangle{x + 10, y + 100, width - 20, 600 - 170}, roles_render.c_str(), &role_scroll, &role_selected);
}

void TableWindow::get_user_files()
{
    if (should_update_users)
    {
        users = project_manager->get_all_entities<User>();

        should_update_users = false;
    }

    static int user_selected = -1;
    static int user_scroll = 0;

    std::string users_render;
    for (const auto& user : users)
    {
        users_render += std::format("id: {}\t name: {}\t email: {}\n", user->id, user->name, user->email);
    }

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "User");

    GuiListView(Rectangle{x + 10, y + 30, width - 20, 200}, users_render.c_str(), &user_scroll, &user_selected);

    static bool update;

    if (IsKeyPressed(KEY_ENTER))
    {
        update = true;
    }

    if (update)
    {
        get_user_files_table = project_manager->get_user_files(*users[user_selected]);

        update = false;
    }

    static int attachment_scroll = 0;
    static int attachment_selected = -1;

    std::string user_files_render;
    for (const auto& attachment : get_user_files_table)
    {
        user_files_render += std::format("file_type: {}\t file_name: {}\n", attachment->file_type, attachment->file_name);
    }

    GuiListView(Rectangle{x + 10, y + 220, width - 20, 300}, user_files_render.c_str(), &attachment_scroll, &attachment_selected);
}

void TableWindow::get_project_tasks()
{
    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    static int project_selected = -1;
    static int project_scroll = 0;

    std::string projects_render;
    for (const auto& project : projects)
    {
        projects_render += std::format("id: {}\t stage: {}\n", project->id, project->fk_project_stage_id);
    }

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "Project");

    GuiListView(Rectangle{x + 10, y + 30, width - 20, 200}, projects_render.c_str(), &project_scroll, &project_selected);

    static bool update = true;

    if (IsKeyPressed(KEY_ENTER))
    {
        update = true;
    }

    if (project_selected == -1 || projects[project_selected] == nullptr)
    {
        return;
    }

    if (update)
    {
        get_project_tasks_table = project_manager->get_project_tasks(*projects[project_selected]);

        update = false;
    }

    std::string project_tasks_render;
    for (const auto& task : get_project_tasks_table)
    {
        project_tasks_render += std::format("stage: {}\t title: {}\n", task->stage_title, task->task_title);
    }

    static int attachment_scroll = 0;
    static int attachment_selected = -1;

    GuiListView(Rectangle{x + 10, y + 220, width - 20, 300}, project_tasks_render.c_str(), &attachment_scroll, &attachment_selected);
}

void TableWindow::get_project_task_details()
{
    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    static int project_selected = -1;
    static int project_scroll = 0;

    static bool update = true;

    std::string projects_render;
    for (const auto& project : projects)
    {
        projects_render += std::format("id: {}\t stage: {}\n", project->id, project->fk_project_stage_id);
    }

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "Project");

    GuiListView(Rectangle{x + 10, y + 30, width - 20, 200}, projects_render.c_str(), &project_scroll, &project_selected);

    if (project_selected == -1 || projects[project_selected] == nullptr)
    {
        return;
    }

    if (update)
    {
        get_project_task_details_table = project_manager->get_project_task_details(*projects[project_selected]);

        update = false;
    }

    if (IsKeyPressed(KEY_ENTER))
    {
        update = true;
    }

    std::string project_tasks_render;
    for (const auto& task : get_project_task_details_table)
    {
        project_tasks_render += std::format("tag: {}\t title: {} \t status: {}\n", task->tag, task->task_title, task->status_title);
    }

    static int attachment_scroll = 0;
    static int attachment_selected = -1;

    GuiListView(Rectangle{x + 10, y + 220, width - 20, 300}, project_tasks_render.c_str(), &attachment_scroll, &attachment_selected);
}

void TableWindow::get_user_comment_counts()
{
    if (should_update_users)
    {
        users = project_manager->get_all_entities<User>();

        should_update_users = false;
    }

    static int user_selected = -1;
    static int user_scroll = 0;

    std::string users_render;
    for (const auto& user : users)
    {
        users_render += std::format("id: {}\t name: {}\t email: {}\n", user->id, user->name, user->email);
    }

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "User");

    GuiListView(Rectangle{x + 10, y + 30, width - 20, 200}, users_render.c_str(), &user_scroll, &user_selected);

    static bool update;

    if (IsKeyPressed(KEY_ENTER))
    {
        update = true;
    }

    if (user_selected == -1 || users[user_selected] == nullptr)
    {
        return;
    }

    if (update)
    {
        get_user_comment_counts_table = project_manager->get_user_comment_counts(*users[user_selected]);

        update = false;
    }

    std::string user_comments_render;
    for (const auto& comment : get_user_comment_counts_table)
    {
        user_comments_render += std::format("user_id: {}\t count: {}\n", comment->user_id, comment->comment_count);
    }

    static int comment_scroll = 0;
    static int comment_selected = -1;

    GuiListView(Rectangle{x + 10, y + 220, width - 20, 300}, user_comments_render.c_str(), &comment_scroll, &comment_selected);
}

void TableWindow::get_project_teams_counts()
{
    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    static int project_selected = -1;
    static int project_scroll = 0;

    static bool update = true;

    std::string projects_render;
    for (const auto& project : projects)
    {
        projects_render += std::format("id: {}\t stage: {}\n", project->id, project->fk_project_stage_id);
    }

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "Project");

    GuiListView(Rectangle{x + 10, y + 30, width - 20, 200}, projects_render.c_str(), &project_scroll, &project_selected);

    if (project_selected == -1 || projects[project_selected] == nullptr)
    {
        return;
    }

    if (update)
    {
        get_project_teams_counts_table = project_manager->get_project_teams_counts(*projects[project_selected]);

        update = false;
    }

    if (IsKeyPressed(KEY_ENTER))
    {
        update = true;
    }

    std::string project_teams_render;
    for (const auto& team : get_project_teams_counts_table)
    {
        project_teams_render += std::format("project_id: {}\t count: {}\n", team->project_id, team->teams_count);
    }

    static int team_scroll = 0;
    static int team_selected = -1;

    GuiListView(Rectangle{x + 10, y + 220, width - 20, 300}, project_teams_render.c_str(), &team_scroll, &team_selected);
}

void TableWindow::search_projects_by_title_draw()
{
    if (should_update_projects)
    {
        projects = project_manager->get_all_entities<Project>();

        should_update_projects = false;
    }

    static char* attachment_size = new char[32];
    static bool editing_size = false;
    static bool updating = false;

    GuiLabel(Rectangle{x + 10, y, 100, 30}, "Project Name");

    GuiTextBox(Rectangle{x + 10, y + 30, width - 20, 30}, attachment_size, 32, editing_size);

    if (GetMousePosition().x > x + 10 && GetMousePosition().x < width - 20 && GetMousePosition().y > y + 30 &&
        GetMousePosition().y < y + 60)
    {
        if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
        {
            editing_size = true;
        }
    }

    if (editing_size)
    {
        if (IsKeyPressed(KEY_ENTER))
        {
            editing_size = false;
            updating = true;
        }
    }

    if (IsKeyPressed(KEY_ENTER))
    {
        updating = true;
    }

    if (updating)
    {
        search_projects_by_title_table = project_manager->search_projects_by_title(attachment_size);

        updating = false;
    }

    std::string projects_render;
    for (const auto& project : search_projects_by_title_table)
    {
        projects_render += std::format("id: {}\t title: {}\t desc: {}\n",
            project->project->id,
            project->project_details->title,
            project->project_details->description);
    }

    static int project_scroll = 0;
    static int project_selected = -1;

    GuiListView(Rectangle{x + 10, y + 60, width - 20, 200}, projects_render.c_str(), &project_scroll, &project_selected);
}