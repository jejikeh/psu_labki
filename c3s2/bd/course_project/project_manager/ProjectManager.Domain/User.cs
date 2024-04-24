namespace ProjectManager.Domain;

public class User
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public IList<UserTeams> UserTeams { get; set; } = [];
}