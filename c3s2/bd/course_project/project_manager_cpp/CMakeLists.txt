cmake_minimum_required(VERSION 3.27)

# PROJECT
project(project_manager_cpp)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++20 -Wall -Wextra -pedantic -Werror -Wno-unused-parameter -Wno-missing-field-initializers -Wno-missing-braces -Wno-deprecated-enum-enum-conversion -Wno-deprecated-enum-compare-conditional -Wno-deprecated-declarations -Wno-unused-variable -Wno-unused-but-set-variable -Wno-c++11-narrowing")

add_executable(${PROJECT_NAME}
        src/main.cxx
        src/models/user.hxx
        src/sql_manager.cxx
        src/sql_manager.hxx
        src/project_manager.cxx
        src/project_manager.hxx
        src/models/role.hxx
        src/models/model.hxx
        src/models/model.hxx
        src/models/model.hxx
        src/models/comment.hxx
        src/models/file_type.hxx
        src/models/attachment.hxx
        src/models/task.hxx
        src/models/project.hxx
        src/models/task_status.hxx
        src/models/task_tag.hxx
        src/models/team.hxx
        src/models/project_details.hxx
        src/models/project_status.hxx
        src/models/project_stage.hxx
        src/models/report.hxx
        src/models/project_reports.hxx
        src/raygui.h
        src/raymath.h
        src/gui/window.hxx
        src/gui/window.cxx
        src/gui/table_window.hxx
        src/gui/table_window.cxx
)

# LIBS

set(LIBS_PATH "libs")

find_package(raylib 3.0 REQUIRED)

# LIBPQXX

add_subdirectory(${LIBS_PATH}/libpqxx build-pqxx)

target_link_libraries(${PROJECT_NAME} PRIVATE pqxx)
target_link_libraries(${PROJECT_NAME} PRIVATE raylib)

# Checks if OSX and links appropriate frameworks (only required on MacOS)
if (APPLE)
    target_link_libraries(${PROJECT_NAME} PRIVATE "-framework IOKit")
    target_link_libraries(${PROJECT_NAME} PRIVATE "-framework Cocoa")
    target_link_libraries(${PROJECT_NAME} PRIVATE "-framework OpenGL")
endif ()

include_directories(${LIBS_PATH}/libpqxx/include/)