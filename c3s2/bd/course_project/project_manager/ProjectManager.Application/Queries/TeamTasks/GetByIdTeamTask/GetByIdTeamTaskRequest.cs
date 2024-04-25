using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.TeamTasks.GetByIdTeamTask;

public class GetByIdTeamTaskRequest : IRequest<TeamTask>
{
    public Guid Id { get; set; }
}