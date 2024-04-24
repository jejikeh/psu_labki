namespace ProjectManager.Domain;

public class Team
{
    public Guid Id { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}