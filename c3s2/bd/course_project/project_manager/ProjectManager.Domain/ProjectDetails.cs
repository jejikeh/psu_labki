namespace ProjectManager.Domain;

public class ProjectDetails
{
    public Guid Id { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public DateOnly StartDate { get; set; }
}