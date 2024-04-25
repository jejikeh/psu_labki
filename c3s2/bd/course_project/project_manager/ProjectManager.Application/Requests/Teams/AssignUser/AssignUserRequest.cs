using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Teams.AssignUser;

public class AssignUserRequest : IRequest<Team>
{
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
}