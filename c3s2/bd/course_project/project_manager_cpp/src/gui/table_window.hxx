#pragma once

#include "../models/comment.hxx"
#include "../models/file_type.hxx"
#include "../models/project_reports.hxx"
#include "../models/task.hxx"
#include "../models/task_tag.hxx"
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
    TaskTag,
    Comment,
    FileType,
    Attachment,

    get_attachment_from_user_bigger_than,
    get_user_roles,
    get_user_files,
    get_project_tasks,
    get_project_task_details,
    get_user_comment_counts,
    get_project_teams_counts,
    search_projects_by_title
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
    bool should_update_task_tags = true;
    bool should_update_comments = true;
    bool should_update_file_type = true;
    bool should_update_attachments = true;

    bool should_update_get_attachment_from_user_bigger_than = true;
    bool should_update_get_user_roles = true;
    bool should_update_get_user_files = true;
    bool should_update_get_project_tasks = true;
    bool should_update_get_project_task_details = true;
    bool should_update_get_user_comment_counts = true;
    bool should_update_get_project_teams_counts = true;
    bool should_update_search_projects_by_title = true;

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

    char* create_task_title;
    char* create_task_description;

    char* create_task_status_title;
    char* create_task_status_description;

    char* create_task_tag_tag;

    char* create_comment_content;
    char* create_created_at;

    char* create_file_type_description;
    char* create_file_type_extension;

    char* create_attachment_content;
    char* create_attachment_name;

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
    std::vector<std::shared_ptr<Task>> tasks;
    std::vector<std::shared_ptr<TaskTag>> task_tags;
    std::vector<std::shared_ptr<Comment>> comments;
    std::vector<std::shared_ptr<FileType>> file_types;
    std::vector<std::shared_ptr<Attachment>> attachments;

    std::vector<std::shared_ptr<Attachment>> get_attachment_from_user_bigger_than_table;
    std::vector<std::shared_ptr<UserRoleInfo>> get_user_roles_table;
    std::vector<std::shared_ptr<UserFile>> get_user_files_table;
    std::vector<std::shared_ptr<ProjectTask>> get_project_tasks_table;
    std::vector<std::shared_ptr<ProjectTaskDetails>> get_project_task_details_table;
    std::vector<std::shared_ptr<UserCommentCount>> get_user_comment_counts_table;
    std::vector<std::shared_ptr<ProjectTeamsCount>> get_project_teams_counts_table;
    std::vector<std::shared_ptr<ProjectSearch>> search_projects_by_title_table;

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

        create_task_title = new char[32];
        create_task_description = new char[32];

        create_task_status_title = new char[32];
        create_task_status_description = new char[32];

        create_task_tag_tag = new char[32];

        create_comment_content = new char[32];
        create_created_at = new char[32];

        create_file_type_description = new char[32];
        create_file_type_extension = new char[32];

        create_attachment_content = new char[32];
        create_attachment_name = new char[32];

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

        delete[] create_task_title;
        delete[] create_task_description;

        delete[] create_task_status_title;
        delete[] create_task_status_description;

        delete[] create_task_tag_tag;

        delete[] create_comment_content;
        delete[] create_created_at;

        delete[] create_file_type_description;
        delete[] create_file_type_extension;

        delete[] create_attachment_content;
        delete[] create_attachment_name;
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
        case TableWindowType::TaskTag:
        {
            title = "Task Tag";

            break;
        }
        case TableWindowType::Comment:
        {
            title = "Comments";

            break;
        }
        case TableWindowType::FileType:
        {
            title = "File Type";

            break;
        }
        case TableWindowType::Attachment:
        {
            title = "Attachment";

            break;
        }

        case TableWindowType::get_attachment_from_user_bigger_than:
        {
            title = "get_attachment_from_user_bigger_than";

            break;
        }

        case TableWindowType::get_user_roles:
        {
            title = "get_user_roles";

            break;
        }

        case TableWindowType::get_user_files:
        {
            title = "get_user_files";

            break;
        }

        case TableWindowType::get_project_tasks:
        {
            title = "get_project_tasks";

            break;
        }

        case TableWindowType::get_project_task_details:
        {
            title = "get_project_task_details";

            break;
        }

        case TableWindowType::get_user_comment_counts:
        {
            title = "get_user_comment_counts";

            break;
        }

        case TableWindowType::get_project_teams_counts:
        {
            title = "get_project_teams_counts";

            break;
        }

        case TableWindowType::search_projects_by_title:
        {
            title = "search_projects_by_title";

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
    void task_tag_draw();
    void comment_draw();
    void file_type_draw();
    void attachment_draw();

    void get_attachment_from_user_bigger_than_draw();
    void get_user_roles();
    void get_user_files();
    void get_project_tasks();
    void get_project_task_details();
    void get_user_comment_counts();
    void get_project_teams_counts();
    void search_projects_by_title_draw();
};