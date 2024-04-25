namespace ProjectManager.Domain;

public class ProjectStatus
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public IList<Project> Projects { get; set; } = [];
}