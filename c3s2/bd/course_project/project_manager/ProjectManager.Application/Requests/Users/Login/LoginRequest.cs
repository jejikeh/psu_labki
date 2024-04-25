using MediatR;
using ProjectManager.Application.Common.Models;

namespace ProjectManager.Application.Requests.Users.Login;

public class LoginRequest : IRequest<AuthorizationToken>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}