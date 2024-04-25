using TaskStatus = ProjectManager.Domain.TaskStatus;

namespace ProjectManager.Application.Services;

public interface ITaskStatusRepository : IRepository<TaskStatus>;
