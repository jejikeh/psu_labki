using MediatR;
using TaskStatus = ProjectManager.Domain.TaskStatus;

namespace ProjectManager.Application.Requests.TaskStatuses.Create;

public class CreateTaskStatusesRequest : IRequest<TaskStatus>
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Staging { get; set; }
}