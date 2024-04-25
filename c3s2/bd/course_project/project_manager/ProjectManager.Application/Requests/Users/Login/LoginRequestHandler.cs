using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Common.Models;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Users.Login;

public class LoginRequestHandler(IUserRepository _userRepository, IAuthorizationTokenService _authorizationTokenService) : IRequestHandler<LoginRequest, AuthorizationToken>
{
    public async Task<AuthorizationToken> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await Predicates.Repositories<User>.ThrowIfNullFromPredicateAsync(_userRepository, Predicates.Users.GetByEmail(request.Email));

        if (!await _userRepository.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedAccessException();
        }
        
        var token = await _authorizationTokenService.CreateAsync(user);
        
        return token;
    }
}