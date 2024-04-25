using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Users.Register;

public class RegisterRequest : IRequest<User>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}