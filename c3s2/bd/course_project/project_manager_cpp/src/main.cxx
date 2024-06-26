#include "gui/table_window.hxx"
#include "models/attachment.hxx"
#include "models/comment.hxx"
#include "models/file_type.hxx"
#include "models/project_details.hxx"
#include "models/project_reports.hxx"
#include "models/project_stage.hxx"
#include "models/report.hxx"
#include "models/task_tag.hxx"
#include "models/user.hxx"
#include "project_manager.hxx"
#include <exception>
#include <iostream>

#define RAYGUI_IMPLEMENTATION
// #include "gui/style_cherry.h"
//  #include "gui/style_ashes.h"
//   #include "gui/style_dark.h"
#include "raygui.h"

int main()
{
    std::string error_message = "";

    InitWindow(800, 600, "Project Manager");

    //    GuiLoadStyleDark();
    //    GuiLoadStyleAshes();
    //    GuiLoadStyleCherry();
    // Main frame
    auto example_window = new TableWindow(280, 25, 780 - 275, 560);

    while (!WindowShouldClose())
    {
        example_window->update();

        BeginDrawing();
        {
            //            ClearBackground(GetColor(0x3a1720ff));
            ClearBackground(WHITE);

            // Main frame
            GuiGroupBox(Rectangle{10, 10, 780, 580}, "Project Manager - main frame");

            example_window->draw();

            if (!error_message.empty())
            {
                GuiMessageBox(Rectangle{10, 30, 780, 560}, "Error", error_message.c_str(), "OK");
            }

            if (example_window->create_window || example_window->delete_window || example_window->update_window)
            {
                goto END_OF_DRAWING;
            }

            // Table selection

            GuiGroupBox(Rectangle{15, 25, 260, 560}, "Tables");

            // Tables

            const float table_label_width = 260;
            const float table_label_height = 10;
            float table_label_y = 35;

            std::int32_t table_index = 1;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Projects").c_str()))
            {
                example_window->set_table_type(TableWindowType::Projects);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Users").c_str()))
            {
                example_window->set_table_type(TableWindowType::Users);
            }
            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Roles").c_str()))
            {
                example_window->set_table_type(TableWindowType::Roles);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Comments").c_str()))
            {
                example_window->set_table_type(TableWindowType::Comment);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "File Types").c_str()))
            {
                example_window->set_table_type(TableWindowType::FileType);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Tasks").c_str()))
            {
                example_window->set_table_type(TableWindowType::Task);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Tasks Statuses").c_str()))
            {
                example_window->set_table_type(TableWindowType::TaskStatus);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Attachments").c_str()))
            {
                example_window->set_table_type(TableWindowType::Attachment);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Task Tags").c_str()))
            {
                example_window->set_table_type(TableWindowType::TaskTag);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Project Details").c_str()))
            {
                example_window->set_table_type(TableWindowType::ProjectDetails);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Project Stages").c_str()))
            {
                example_window->set_table_type(TableWindowType::ProjectStages);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Project Statuses").c_str()))
            {
                example_window->set_table_type(TableWindowType::ProjectStatus);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Reports").c_str()))
            {
                example_window->set_table_type(TableWindowType::Report);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Project Reports").c_str()))
            {
                example_window->set_table_type(TableWindowType::ProjectReports);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "Teams").c_str()))
            {
                example_window->set_table_type(TableWindowType::Team);
            }

            table_label_y += table_label_height + 5;

            GuiLine(Rectangle{25, table_label_y, table_label_width - 10, table_label_height}, "Getters");

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_attachment_from_user_bigger_than").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_attachment_from_user_bigger_than);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_user_roles").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_user_roles);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_user_files").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_user_files);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_project_tasks").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_project_tasks);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_project_task_details").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_project_task_details);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_user_comment_counts").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_user_comment_counts);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "get_project_teams_counts").c_str()))
            {
                example_window->set_table_type(TableWindowType::get_project_teams_counts);
            }

            table_label_y += table_label_height + 5;
            table_index++;

            if (GuiLabelButton(Rectangle{25, table_label_y, table_label_width, table_label_height},
                    std::format("{} - {}", table_index, "search_projects_by_title").c_str()))
            {
                example_window->set_table_type(TableWindowType::search_projects_by_title);
            }
        }
    END_OF_DRAWING:

        EndDrawing();
    }

    return EXIT_SUCCESS;
}
/*
auto project_manager = std::make_unique<ProjectManager>();

project_manager->drop_table();
project_manager->init_table();

const auto admin_role = Role("admin", "admin", 12);
project_manager->create_model(admin_role);

auto user = User("test", "test", "test");
user.assign_role(admin_role);

project_manager->create_model(user);

auto user_query = User();
user_query.id = user.id;

const auto returned_user = project_manager->get_entity_by_id(&user_query);

//    std::cout << "Users" << std::endl;
//    std::cout << "id: " << returned_user->id << std::endl;
//    std::cout << "name: " << returned_user->name << std::endl;
//    std::cout << "fk_role_id: " << returned_user->fk_role_id << std::endl;

const auto returned_role = project_manager->get_entity_by_id(&admin_role);

//    std::cout << "Roles" << std::endl;
//    std::cout << "id: " << returned_role->id << std::endl;
//    std::cout << "name: " << returned_role->name << std::endl;
//    std::cout << "description: " << returned_role->description << std::endl;

auto comment = Comment("hello, world");
comment.assign_author(*returned_user);

project_manager->create_model(comment);

auto comment_query = Comment();
comment_query.id = comment.id;

const auto returned_comment = project_manager->get_entity_by_id(&comment_query);

//    std::cout << "Comments" << std::endl;
//    std::cout << "text: " << returned_comment->content << std::endl;
//    std::cout << "fk_author_id: " << returned_comment->fk_author_id << std::endl;

auto file_type = FileType(".txt");
project_manager->create_model(file_type);

auto file_type_query = FileType();
file_type_query.id = file_type.id;

const auto returned_file_type = project_manager->get_entity_by_id(&file_type_query);

//    std::cout << "File types" << std::endl;
//    std::cout << "id: " << returned_file_type->id << std::endl;
//    std::cout << "extension: " << returned_file_type->extension << std::endl;

auto attachment = Attachment("hello_world", "hello_world.txt", 1234);
attachment.assign_author_and_file_type(*returned_user, *returned_file_type);

project_manager->create_model(attachment);

attachment.id = "hello_world_2";
attachment.file_size = 1322;
attachment.file_name = "hello_world_2.txt";

project_manager->create_model(attachment);

auto attachment_query = Attachment();
attachment_query.id = attachment.id;

const auto returned_attachment = project_manager->get_entity_by_id(&attachment_query);

//    std::cout << "Attachments" << std::endl;
//    std::cout << "fk_author_id: " << returned_attachment->fk_author_id << std::endl;
//    std::cout << "fk_file_type_id: " << returned_attachment->fk_file_type_id << std::endl;

const auto big_attachments = project_manager->get_attachment_from_user_bigger_than(10);
////    std::cout << "Big attachments" << std::endl;
//    for (const auto& a : big_attachments)
//    {
////        std::cout << "  fk_author_id: " << a->fk_author_id << std::endl;
////        std::cout << "  fk_file_type_id: " << a->fk_file_type_id << std::endl;
////        std::cout << "  size: " << a->file_size << std::endl;
////        std::cout << "  --" << std::endl;
//    }

auto task_status = TaskStatus("todo", "in progress", true);

project_manager->create_model(task_status);

auto task_status_query = TaskStatus();
task_status_query.id = task_status.id;

const auto returned_task_status = project_manager->get_entity_by_id(&task_status_query);

////    std::cout << "Task statuses" << std::endl;
////    std::cout << "id: " << returned_task_status->id << std::endl;
////    std::cout << "title: " << returned_task_status->title << std::endl;
////    std::cout << "description: " << returned_task_status->description << std::endl;
////    std::cout << "staging: " << returned_task_status->staging << std::endl;

auto project_status = ProjectStatus("todo", "in progress");
project_manager->create_model(project_status);

auto project_status_query = ProjectStatus();
project_status_query.id = project_status.id;

const auto returned_project_status = project_manager->get_entity_by_id(&project_status_query);

////    std::cout << "Project statuses" << std::endl;
////    std::cout << "id: " << returned_project_status->id << std::endl;
////    std::cout << "title: " << returned_project_status->title << std::endl;
////    std::cout << "description: " << returned_project_status->description << std::endl;

auto project_stage = ProjectStage("todo", "in progress", "2022-01-01 00:00:00", "2024-01-02 00:00:00");
project_manager->create_model(project_stage);

auto project_stage_query = ProjectStage();
project_stage_query.id = project_stage.id;

const auto returned_project_stage = project_manager->get_entity_by_id(&project_stage_query);

////    std::cout << "Project stages" << std::endl;
////    std::cout << "id: " << returned_project_stage->id << std::endl;
////    std::cout << "title: " << returned_project_stage->title << std::endl;
////    std::cout << "description: " << returned_project_stage->description << std::endl;
////    std::cout << "start_date: " << returned_project_stage->start_date << std::endl;
////    std::cout << "end_date: " << returned_project_stage->end_date << std::endl;

auto report = Report(100, "buy me a coffee");
project_manager->create_model(report);

auto report_query = Report();
report_query.id = report.id;

const auto returned_report = project_manager->get_entity_by_id(&report_query);

////    std::cout << "Reports" << std::endl;
////    std::cout << "id: " << returned_report->id << std::endl;
////    std::cout << "value: " << returned_report->value << std::endl;
////    std::cout << "description: " << returned_report->description << std::endl;

auto project = Project();
project.assign_project_status(*returned_project_status);
project.assign_project_stage(*returned_project_stage);

project_manager->create_model(project);

auto project_query = Project();
project_query.id = project.id;

const auto returned_project = project_manager->get_entity_by_id(&project_query);

//    std::cout << "Projects" << std::endl;
//    std::cout << "id: " << returned_project->id << std::endl;

auto project_details = ProjectDetails("Project 1", "Game about life");
project_details.assign_project(*returned_project);

project_manager->create_model(project_details);

auto project_details_query = ProjectDetails();
project_details_query.id = project_details.id;

const auto returned_project_details = project_manager->get_entity_by_id(&project_details_query);

//    std::cout << "Project details" << std::endl;
//    std::cout << "name: " << returned_project_details->title << std::endl;
//    std::cout << "description: " << returned_project_details->description << std::endl;

auto team = Team("team");
team.assign_project(*returned_project);

project_manager->create_model(team);

auto team_query = Team();
team_query.id = team.id;

const auto returned_team = project_manager->get_entity_by_id(&team_query);

//    std::cout << "Teams" << std::endl;
//    std::cout << "id: " << returned_team->id << std::endl;
//    std::cout << "description: " << returned_team->description << std::endl;

auto task = Task("task", "task description");
task.assign_task_status(*returned_task_status);
task.assign_team(*returned_team);

project_manager->create_model(task);

auto task_query = Task();
task_query.id = task.id;

const auto returned_task = project_manager->get_entity_by_id(&task_query);

//    std::cout << "Tasks" << std::endl;
//    std::cout << "fk_task_status_id: " << returned_task->fk_task_status_id << std::endl;
//    std::cout << "fk_team_id: " << returned_task->fk_team_id << std::endl;
//    std::cout << "description: " << returned_task->description << std::endl;
//    std::cout << "title: " << returned_task->title << std::endl;

auto task_tag = TaskTag("bug");
task_tag.assign_to_task(*returned_task);

project_manager->create_model(task_tag);

auto task_tag_query = TaskTag();
task_tag_query.id = task_tag.id;

const auto returned_task_tag = project_manager->get_entity_by_id(&task_tag_query);

//    std::cout << "Task tags" << std::endl;
//    std::cout << "id: " << returned_task_tag->id << std::endl;
//    std::cout << "fk_task_id: " << returned_task_tag->fk_task_id << std::endl;
//    std::cout << "tag: " << returned_task_tag->tag << std::endl;

auto project_report = ProjectReports();
project_report.assign_report_and_project(*returned_report, *returned_project);

project_manager->create_model(project_report);

auto project_report_query = ProjectReports();
project_report_query.id = project_report.id;

const auto returned_project_report = project_manager->get_entity_by_id(&project_report_query);

//    std::cout << "Project reports" << std::endl;
//    std::cout << "id: " << returned_project_report->id << std::endl;
//    std::cout << "fk_project_id: " << returned_project_report->fk_project_id << std::endl;
//    std::cout << "fk_report_id: " << returned_project_report->fk_report_id << std::endl;

const auto user_roles = project_manager->get_user_roles();

std::cout << "User roles" << std::endl;
for (const auto& user_role : user_roles)
{
    std::cout << "id: " << user_role->name << std::endl;
    std::cout << "fk_user_id: " << user_role->email << std::endl;
    std::cout << "fk_role_id: " << user_role->role_name << std::endl;
}
const auto project_attachemts = project_manager->get_user_files(*returned_user);

std::cout << "Project attachments" << std::endl;
for (const auto& o : project_attachemts)
{
    std::cout << "id: " << o->file_name << std::endl;
    std::cout << "fk_project_id: " << o->file_type << std::endl;
}

const auto project_tasks = project_manager->get_project_tasks(*returned_project);

std::cout << "Project tasks" << std::endl;
for (const auto& o : project_tasks)
{
    std::cout << "id: " << o->stage_title << std::endl;
    std::cout << "fk_project_id: " << o->task_title << std::endl;
}

const auto project_task_details = project_manager->get_project_task_details(*returned_project);

std::cout << "Project task details" << std::endl;
for (const auto& o : project_task_details)
{
    std::cout << "id: " << o->task_title << std::endl;
    std::cout << "fk_project_id: " << o->tag << std::endl;
    std::cout << "fk_task_id: " << o->status_title << std::endl;
}

const auto user_comments = project_manager->get_user_comment_counts(*returned_user);

std::cout << "User comments" << std::endl;
for (const auto& o : user_comments)
{
    std::cout << "id: " << o->user_id << std::endl;
    std::cout << "fk_comment_id: " << o->comment_count << std::endl;
}

const auto project_comments = project_manager->get_project_teams_counts(*returned_project);

std::cout << "Project comments" << std::endl;
for (const auto& o : project_comments)
{
    std::cout << "id: " << o->project_id << std::endl;
    std::cout << "fk_comment_id: " << o->teams_count << std::endl;
}

const auto find_project = project_manager->search_projects_by_title("Proj");

std::cout << "Find project" << std::endl;
for (const auto& o : find_project)
{
    std::cout << "id: " << o->project_details->title << std::endl;
}

return EXIT_SUCCESS;
//}
*/