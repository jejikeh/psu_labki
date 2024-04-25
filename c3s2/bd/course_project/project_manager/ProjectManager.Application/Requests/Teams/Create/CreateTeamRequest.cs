using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Teams.Create;

public class CreateTeamRequest : IRequest<Team>
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}