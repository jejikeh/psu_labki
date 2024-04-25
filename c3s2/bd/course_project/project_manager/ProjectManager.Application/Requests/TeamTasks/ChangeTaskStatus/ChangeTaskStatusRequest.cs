using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TeamTasks.ChangeTaskStatus;

public class ChangeTaskStatusRequest : IRequest<TeamTask>
{
    public Guid TaskId { get; set; }
    public Guid TaskStatusId { get; set; }
}