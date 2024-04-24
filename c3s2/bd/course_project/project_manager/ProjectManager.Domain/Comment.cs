namespace ProjectManager.Domain;

public class Comment
{
    public Guid Id { get; set; }
    
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;
    
    public string Text { get; set; } = null!;
    
    public DateOnly CreatedAt { get; set; }
}