#pragma once

#include "../models/project_reports.hxx"
#include "../models/task.hxx"
#include "../models/team.hxx"
#include "../project_manager.hxx"
#include "../raygui.h"
#include "window.hxx"

enum class TableWindowType
{
    None,
    Users,
    Roles,
    Projects,
    ProjectDetails,
    ProjectStatus,
    ProjectStages,
    ProjectReports,
    Team,
    Report,
    Task,
    TaskStatus,
};

class TableWindow final : public Window
{
public:
    std::unique_ptr<ProjectManager> project_manager;

    TableWindowType table_type = TableWindowType::None;

    bool create_window;
    bool delete_window;
    bool update_window;

    bool should_update_users = true;
    bool should_update_roles = true;
    bool should_update_projects = true;
    bool should_update_projects_statuses = true;
    bool should_update_projects_details = true;
    bool should_update_project_stages = true;
    bool should_update_project_reports = true;
    bool should_update_teams = true;
    bool should_update_reports = true;
    bool should_update_tasks = true;
    bool should_update_task_status = true;

    char* create_user_name;
    char* create_user_email;
    char* create_user_password;

    char* create_role_name;
    char* create_role_description;
    char* create_role_priority;

    char* create_project_details_title;
    char* create_project_details_description;
    char* create_project_details_end_date;

    char* create_project_status_title;
    char* create_project_status_description;

    char* create_project_stage_title;
    char* create_project_stage_description;
    char* create_project_stage_start_date;
    char* create_project_stage_end_date;

    char* create_team_description;

    char* create_report_description;
    char* create_report_value;

    char* create_task_description;

    char* create_task_status_title;
    char* create_task_status_description;

    std::vector<std::shared_ptr<User>> users;
    std::vector<std::shared_ptr<Role>> roles;
    std::vector<std::shared_ptr<Project>> projects;
    std::vector<std::shared_ptr<ProjectStatus>> project_statuses;
    std::vector<std::shared_ptr<ProjectStage>> project_stages;
    std::vector<std::shared_ptr<ProjectDetails>> project_details;
    std::vector<std::shared_ptr<ProjectReports>> project_reports;
    std::vector<std::shared_ptr<Report>> reports;
    std::vector<std::shared_ptr<Team>> teams;
    std::vector<std::shared_ptr<TaskStatus>> task_statuses;

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

        create_project_details_title = new char[32];
        create_project_details_description = new char[32];
        create_project_details_end_date = new char[32];

        create_project_status_title = new char[32];
        create_project_status_description = new char[32];

        create_project_stage_title = new char[32];
        create_project_stage_description = new char[32];
        create_project_stage_start_date = new char[32];
        create_project_stage_end_date = new char[32];

        create_team_description = new char[32];

        create_report_description = new char[32];
        create_report_value = new char[32];

        create_task_description = new char[32];

        create_task_status_title = new char[32];
        create_task_status_description = new char[32];

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

        delete[] create_project_details_title;
        delete[] create_project_details_description;
        delete[] create_project_details_end_date;

        delete[] create_project_status_title;
        delete[] create_project_status_description;

        delete[] create_project_stage_title;
        delete[] create_project_stage_description;
        delete[] create_project_stage_start_date;
        delete[] create_project_stage_end_date;

        delete[] create_team_description;

        delete[] create_report_description;
        delete[] create_report_value;

        delete[] create_task_description;

        delete[] create_task_status_title;
        delete[] create_task_status_description;
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
        case TableWindowType::ProjectDetails:
        {
            title = "Project Details";

            break;
        }
        case TableWindowType::ProjectStatus:
        {
            title = "Project Status";

            break;
        }
        case TableWindowType::ProjectStages:
        {
            title = "Project Stages";

            break;
        }
        case TableWindowType::ProjectReports:
        {
            title = "Project Reports";

            break;
        }
        case TableWindowType::Team:
        {
            title = "Teams";

            break;
        }
        case TableWindowType::Report:
        {
            title = "Report";

            break;
        }
        case TableWindowType::Task:
        {
            title = "Task";

            break;
        }
        case TableWindowType::TaskStatus:
        {
            title = "Task Status";

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
    void project_details_draw();
    void project_status_draw();
    void project_stages_draw();
    void project_reports_draw();
    void team_draw();
    void report_draw();
    void task_draw();
    void task_status_draw();
};