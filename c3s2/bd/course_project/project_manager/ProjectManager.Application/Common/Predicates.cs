using ProjectManager.Application.Common.Exceptions;
using ProjectManager.Application.Services;
using ProjectManager.Domain;
using TaskStatus = ProjectManager.Domain.TaskStatus;

namespace ProjectManager.Application.Common;

public static class Predicates
{
    public static class Attachments
    {
        public static Func<Attachment, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class FileTypes
    {
        public static Func<FileType, bool> GetById(Guid id) => x => x.Id == id;
        public static Func<FileType, bool> GetByName(string name) => x => x.Name == name;
        public static Func<FileType, bool> GetByExtension(string extension) => x => x.Extension == extension;
    }

    public static class Users
    {
        public static Func<User, bool> GetById(Guid id) => x => x.Id == id;
        public static Func<User, bool> GetByEmail(string email) => x => x.Email == email;
    }

    public static class Roles
    {
        public static Func<Role, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class Projects
    {
        public static Func<Project, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class Repositories<T>
    {
        public static async Task<T> ThrowIfNullFromPredicateAsync(IRepository<T> repository, Func<T, bool> predicate)
        {
            var entity = await repository.GetByPredicateAsync(predicate);

            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, predicate.Method.GetParameters()[0].Name ?? throw new InvalidOperationException("Parameter name is null"));
            }
            
            return entity;
        }
    }

    public static class Comments
    {
        public static Func<Comment, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class Teams
    {
        public static Func<Team, bool> GetById(Guid id) => x => x.Id == id;
        public static Func<Team, bool> GetByProjectId(Guid projectId) => x => x.ProjectId == projectId;
    }

    public static class TeamTasks
    {
        public static Func<TeamTask, bool> GetById(Guid id) => x => x.Id == id;
        public static Func<TeamTask, bool> GetByTeamId(Guid teamId) => x => x.TeamId == teamId;
    }

    public static class TasksTags
    {
        public static Func<TaskTag, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class TaskStatuses
    {
        public static Func<TaskStatus, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class ProjectStatuses
    {
        public static Func<ProjectStatus, bool> GetById(Guid id) => x => x.Id == id;
    }
}