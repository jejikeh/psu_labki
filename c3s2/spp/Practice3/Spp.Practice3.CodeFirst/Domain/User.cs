namespace Spp.Practice3.CodeFirst.Domain;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string NickName { get; set; } = string.Empty;
    public ICollection<Note> Notes { get; set; } = new List<Note>();
}