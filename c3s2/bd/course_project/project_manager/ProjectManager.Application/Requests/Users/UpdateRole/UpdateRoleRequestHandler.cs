using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Users.UpdateRole;

public class UpdateRoleRequestHandler(IUserRepository _userRepository, IRoleRepository _roleRepository) : IRequestHandler<UpdateRoleRequest, Unit>
{
    public async Task<Unit> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        await _userRepository.SetRoleAsync(
            await Predicates.Repositories<User>.ThrowIfNullFromPredicateAsync(_userRepository, Predicates.Users.GetById(request.UserId)), 
            await Predicates.Repositories<Role>.ThrowIfNullFromPredicateAsync(_roleRepository, Predicates.Roles.GetById(request.RoleId)));
        
        return Unit.Value;
    }
}