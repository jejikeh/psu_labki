namespace ProjectManager.Domain;

public class Attachment
{
    public Guid Id { get; set; }
    
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;
    
    public Guid FileTypeId { get; set; }
    public FileType FileType { get; set; } = null!;
    
    public string Content { get; set; } = null!;
}