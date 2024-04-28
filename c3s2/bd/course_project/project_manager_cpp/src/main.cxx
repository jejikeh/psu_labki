#include <iostream>
#include <exception>
#include "project_manager.hxx"
#include "models/user.hxx"
#include "models/comment.hxx"
#include "models/file_type.hxx"
#include "models/attachment.hxx"

int main()
{
    auto project_manager = std::make_unique<ProjectManager>();

    project_manager->drop_table();
    project_manager->init_table();

    const auto admin_role = Role("admin", "admin");
    project_manager->create_model(admin_role);

    auto user = User("test", "test", "test");
    user.assign_role(admin_role);

    project_manager->create_model(user);

    auto user_query = User();
    user_query.id = user.id;

    const auto returned_user = project_manager->get_entity_by_id(&user_query);

    std::cout << "Users" << std::endl;
    std::cout << "id: " << returned_user->id << std::endl;
    std::cout << "name: " << returned_user->name << std::endl;
    std::cout << "fk_role_id: " << returned_user->fk_role_id << std::endl;

    const auto returned_role = project_manager->get_entity_by_id(&admin_role);

    std::cout << "Roles" << std::endl;
    std::cout << "id: " << returned_role->id << std::endl;
    std::cout << "name: " << returned_role->name << std::endl;
    std::cout << "description: " << returned_role->description << std::endl;

    auto comment = Comment("hello, world");
    comment.assign_author(*returned_user);

    project_manager->create_model(comment);

    auto comment_query = Comment();
    comment_query.id = comment.id;

    const auto returned_comment = project_manager->get_entity_by_id(&comment_query);

    std::cout << "Comments" << std::endl;
    std::cout << "text: " << returned_comment->content << std::endl;
    std::cout << "fk_author_id: " << returned_comment->fk_author_id << std::endl;

    auto file_type = FileType(".png");
    project_manager->create_model(file_type);

    auto file_type_query = FileType();
    file_type_query.id = file_type.id;

    const auto returned_file_type = project_manager->get_entity_by_id(&file_type_query);

    std::cout << "File types" << std::endl;
    std::cout << "id: " << returned_file_type->id << std::endl;
    std::cout << "extension: " << returned_file_type->extension << std::endl;

    auto attachment = Attachment();

    attachment.assign_author_and_file_type(*returned_user, *returned_file_type);

    project_manager->create_model(attachment);

    auto attachment_query = Attachment();
    attachment_query.id = attachment.id;

    const auto returned_attachment = project_manager->get_entity_by_id(&attachment_query);

    std::cout << "Attachments" << std::endl;
    std::cout << "fk_author_id: " << returned_attachment->fk_author_id << std::endl;
    std::cout << "fk_file_type_id: " << returned_attachment->fk_file_type_id << std::endl;

    return EXIT_SUCCESS;
}
