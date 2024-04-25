using MediatR;

namespace ProjectManager.Application.Requests.TeamTasks.Delete;

public class DeleteTeamTaskRequest : IRequest
{
    public Guid Id { get; set; }
}