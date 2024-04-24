namespace PresentationProject.Web.Models;

public class Game
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
    
    public float Rating { get; set; }
    
    public DateOnly ReleaseDate { get; set; }
    
    public int DeveloperId { get; set; }
    
    public Developer Developer { get; set; } = null!;
}