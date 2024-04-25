using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Teams.GetAllOnProject;

public class GetAllOnProjectRequest : IRequest<IEnumerable<Team>>
{
    public Guid ProjectId { get; set; }
    public int Page { get; set; }
    public int Take { get; set; }
}