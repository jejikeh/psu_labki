using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.TeamTasks.GetAllOnTeam;

public class GetAllOnTeamTasksRequest : IRequest<IEnumerable<TeamTask>>
{
    public Guid TeamId { get; set; }
    public int Page { get; set; }
    public int Take { get; set; }
}