using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Users.Register;

public class RegisterRequestHandler(IUserRepository _userRepository) : IRequestHandler<RegisterRequest, User>
{
    public Task<User> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email
        };
        
        var result = _userRepository.CreateAsync(user, request.Password);
        
        return result;
    }
}