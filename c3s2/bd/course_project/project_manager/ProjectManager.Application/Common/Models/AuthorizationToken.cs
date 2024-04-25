namespace ProjectManager.Application.Common.Models;

public class AuthorizationToken
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
}