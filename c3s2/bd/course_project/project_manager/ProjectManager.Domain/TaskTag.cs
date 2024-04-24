namespace ProjectManager.Domain;

public class TaskTag
{
    public Guid Id { get; set; }

    public string Tag { get; set; } = string.Empty;
    
    public Guid TaskId { get; set; }
    public Task Task { get; set; } = null!;
}