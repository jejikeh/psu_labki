namespace ProjectManager.Domain;

public class TeamTask
{
    public Guid Id { get; set; }
    
    public Guid TeamId { get; set; }
    public Team Team { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public Guid TaskStatusId { get; set; }
    public TaskStatus TaskStatus { get; set; } = null!;

    public IList<TaskTag> TaskTags { get; set; } = [];
}