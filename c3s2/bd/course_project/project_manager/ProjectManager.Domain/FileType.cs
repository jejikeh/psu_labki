namespace ProjectManager.Domain;

public class FileType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
}