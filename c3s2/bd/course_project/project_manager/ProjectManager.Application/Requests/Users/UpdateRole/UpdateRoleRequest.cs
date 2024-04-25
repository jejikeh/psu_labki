using MediatR;

namespace ProjectManager.Application.Requests.Users.UpdateRole;

public class UpdateRoleRequest : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}