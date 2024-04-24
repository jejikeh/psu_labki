namespace ProjectManager.Domain;

public class UserTeams
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }

    public User User { get; set; } = null!;
    public Team Team { get; set; } = null!;
}