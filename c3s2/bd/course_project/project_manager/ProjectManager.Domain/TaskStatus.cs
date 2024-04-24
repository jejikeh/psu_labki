namespace ProjectManager.Domain;

public class TaskStatus
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public bool Staging { get; set; }

    public IList<TeamTask> TeamTasks { get; set; } = [];
}