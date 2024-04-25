using Microsoft.AspNetCore.Identity;

namespace ProjectManager.Domain;

public class User : IdentityUser<Guid>
{
    public IList<UserTeams> UserTeams { get; set; } = [];
}