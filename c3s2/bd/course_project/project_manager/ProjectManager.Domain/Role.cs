using Microsoft.AspNetCore.Identity;

namespace ProjectManager.Domain;

public class Role : IdentityUser<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
}