using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TeamTasks.Create;

public class CreateTeamTaskRequest : IRequest<TeamTask>
{
    public Guid TeamId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public Guid TaskStatusId { get; set; }
}