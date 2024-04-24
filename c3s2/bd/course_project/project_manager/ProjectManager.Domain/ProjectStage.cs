namespace ProjectManager.Domain;

public class ProjectStage
{
    public Guid Id { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}