#include <string>
#include <iostream>
#include "project_manager.hxx"
#include "models/user.hxx"
#include "models/comment.hxx"
#include "models/file_type.hxx"
#include "models/attachment.hxx"
#include "models/task_tag.hxx"
#include "models/task_status.hxx"
#include "models/project_details.hxx"
#include "models/project_status.hxx"
#include "models/report.hxx"
#include "models/project_reports.hxx"
#include "models/attachment.hxx"

ProjectManager::ProjectManager()
{
    sql_manager = std::make_unique<SQLManager>(PROJECT_MANAGER_CONNECTION_STRING);
}

void ProjectManager::init_table() const
{
    execute_sql(Role::to_create_table_sql(), false);
    execute_sql(User::to_create_table_sql(), false);

    execute_sql(Comment::to_create_table_sql(), false);
    execute_sql(FileType::to_create_table_sql(), false);
    execute_sql(Attachment::to_create_table_sql(), false);

    execute_sql(TaskStatus::to_create_table_sql(), false);

    execute_sql(Report::to_create_table_sql(), false);

    execute_sql(ProjectStatus::to_create_table_sql(), false);
    execute_sql(ProjectStage::to_create_table_sql(), false);
    execute_sql(Project::to_create_table_sql(), false);
    execute_sql(ProjectDetails::to_create_table_sql(), false);

    execute_sql(ProjectReports::to_create_table_sql(), false);

    execute_sql(Team::to_create_table_sql(), false);

    execute_sql(Task::to_create_table_sql(), false);
    execute_sql(TaskTag::to_create_table_sql(), false);
}

void ProjectManager::drop_table() const
{
    const auto drop_sql_query = [](const std::string& table_name) { return "DROP TABLE IF EXISTS " + table_name + " CASCADE;"; };

    execute_sql(drop_sql_query(User::s_table_name()), false);
    execute_sql(drop_sql_query(Role::s_table_name()), false);

    execute_sql(drop_sql_query(Comment::s_table_name()), false);
    execute_sql(drop_sql_query(FileType::s_table_name()), false);
    execute_sql(drop_sql_query(Attachment::s_table_name()), false);

    execute_sql(drop_sql_query(TaskStatus::s_table_name()), false);

    execute_sql(drop_sql_query(Report::s_table_name()), false);

    execute_sql(drop_sql_query(ProjectStatus::s_table_name()), false);
    execute_sql(drop_sql_query(ProjectStage::s_table_name()), false);
    execute_sql(drop_sql_query(Project::s_table_name()), false);
    execute_sql(drop_sql_query(ProjectDetails::s_table_name()), false);

    execute_sql(drop_sql_query(ProjectReports::s_table_name()), false);

    execute_sql(drop_sql_query(Team::s_table_name()), false);

    execute_sql(drop_sql_query(Task::s_table_name()), false);
    execute_sql(drop_sql_query(TaskTag::s_table_name()), false);
}

pqxx::result ProjectManager::execute_sql(const std::string& sql, const bool throw_on_error) const
{
    std::cout << sql << std::endl;

    const auto result = sql_manager->execute(sql);

    if (throw_on_error && result.affected_rows() == 0)
    {
        throw std::runtime_error("Failed to execute SQL query: " + sql);
    }

    return result;
}

void ProjectManager::create_model(const ModelEntity& entity) const
{
    execute_sql(entity.to_insert_sql());
}

std::vector<std::shared_ptr<Attachment>> ProjectManager::get_attachment_from_user_bigger_than(std::int32_t size)
{
    const auto select_sql =
        "SELECT * FROM " + Attachment::s_table_name() + " WHERE file_size > " + std::to_string(size) + " ORDER BY file_size DESC LIMIT 10;";

    const auto result = execute_sql(select_sql);

    auto attachments = std::vector<std::shared_ptr<Attachment>>();

    for (const auto& row : result)
    {
        auto attachment = std::make_shared<Attachment>();
        attachment->from_pqxx_row(row);

        attachments.push_back(attachment);
    }

    return attachments;
}

std::vector<std::shared_ptr<UserRoleInfo>> ProjectManager::get_user_roles()
{
    const std::string select_sql = "SELECT " + User::s_table_name() + ".name, " + User::s_table_name() + ".email, " + Role::s_table_name() +
                                   ".name AS role_name \n"
                                   "FROM " +
                                   User::s_table_name() +
                                   "\n"
                                   "INNER JOIN " +
                                   Role::s_table_name() + " ON " + User::s_table_name() + ".fk_role_id = " + Role::s_table_name() + ".id;";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<UserRoleInfo>> user_roles;

    for (const auto& row : result)
    {
        auto user_role = std::make_shared<UserRoleInfo>();
        user_role->from_pqxx_row(row);

        user_roles.push_back(user_role);
    }

    return user_roles;
}

std::vector<std::shared_ptr<UserFile>> ProjectManager::get_user_files(const User& user)
{
    const std::string select_sql = "SELECT attachments.file_name, file_types.extension AS file_type \n"
                                   "FROM attachments \n"
                                   "INNER JOIN file_types ON attachments.fk_file_type_id = file_types.id \n"
                                   "INNER JOIN users ON users.id = '" +
                                   user.id +
                                   "' "
                                   "WHERE users.id = attachments.fk_author_id;";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<UserFile>> project_files;

    for (const auto& row : result)
    {
        auto user_file = std::make_shared<UserFile>();
        user_file->from_pqxx_row(row);

        project_files.push_back(user_file);
    }

    return project_files;
}

std::vector<std::shared_ptr<ProjectTask>> ProjectManager::get_project_tasks(const Project& project)
{
    const std::string select_sql = "SELECT project_stages.title AS stage_title, tasks.title AS task_title \n"
                                   "FROM project_stages, tasks \n"
                                   "INNER JOIN teams ON teams.fk_project_id = '" +
                                   project.id + "';\n";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<ProjectTask>> project_tasks;

    for (const auto& row : result)
    {
        auto project_task = std::make_shared<ProjectTask>();
        project_task->from_pqxx_row(row);

        project_tasks.push_back(project_task);
    }

    return project_tasks;
}

std::vector<std::shared_ptr<ProjectTaskDetails>> ProjectManager::get_project_task_details(const Project& project)
{
    const std::string select_sql = "SELECT tasks.title AS task_title, task_statuses.title AS status_title, task_tags.tag \n"
                                   "FROM tasks \n"
                                   "INNER JOIN task_statuses ON tasks.fk_task_status_id = task_statuses.id \n"
                                   "LEFT JOIN task_tags ON tasks.id = task_tags.fk_task_id \n"
                                   "WHERE tasks.fk_team_id IN (SELECT id FROM teams WHERE fk_project_id = '" +
                                   project.id + "');";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<ProjectTaskDetails>> project_task_details;

    for (const auto& row : result)
    {
        auto task_detail = std::make_shared<ProjectTaskDetails>();
        task_detail->from_pqxx_row(row);

        project_task_details.push_back(task_detail);
    }

    return project_task_details;
}

std::vector<std::shared_ptr<UserCommentCount>> ProjectManager::get_user_comment_counts(const User& project)
{
    const std::string select_sql = "SELECT comments.fk_author_id as user_id, COUNT(comments.id) AS comment_count \n"
                                   "FROM comments \n"
                                   "WHERE comments.fk_author_id = '" +
                                   project.id +
                                   "' \n"
                                   "GROUP BY comments.fk_author_id;";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<UserCommentCount>> task_comment_counts;

    for (const auto& row : result)
    {
        auto comment_count = std::make_shared<UserCommentCount>();
        comment_count->from_pqxx_row(row);

        task_comment_counts.push_back(comment_count);
    }

    return task_comment_counts;
}

std::vector<std::shared_ptr<ProjectTeamsCount>> ProjectManager::get_project_teams_counts(const Project& project)
{
    const std::string select_sql = "SELECT teams.fk_project_id as project_id, COUNT(teams.id) AS teams_count \n"
                                   "FROM teams \n"
                                   "WHERE teams.fk_project_id = '" +
                                   project.id +
                                   "' \n"
                                   "GROUP BY teams.fk_project_id;";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<ProjectTeamsCount>> project_teams_counts;

    for (const auto& row : result)
    {
        auto project_teams_count = std::make_shared<ProjectTeamsCount>();
        project_teams_count->from_pqxx_row(row);

        project_teams_counts.push_back(project_teams_count);
    }

    return project_teams_counts;
}

std::vector<std::shared_ptr<ProjectSearch>> ProjectManager::search_projects_by_title(const std::string& title)
{
    const std::string select_sql = "SELECT * FROM project_details WHERE title LIKE '%" + title + "%';";

    const auto result = execute_sql(select_sql);

    std::vector<std::shared_ptr<ProjectSearch>> projects;

    for (const auto& row : result)
    {
        auto project_details = std::make_shared<ProjectDetails>();
        project_details->from_pqxx_row(row);

        auto query_project = Project();
        query_project.id = project_details->id;

        auto project = get_entity_by_id(&query_project);

        auto project_search = std::make_shared<ProjectSearch>();
        project_search->project = std::make_unique<Project>(*project);
        project_search->project_details = std::make_unique<ProjectDetails>(*project_details);

        projects.push_back(project_search);
    }

    return projects;
}
