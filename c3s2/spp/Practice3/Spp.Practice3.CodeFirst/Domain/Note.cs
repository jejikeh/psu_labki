using System.Text.Json.Serialization;

namespace Spp.Practice3.CodeFirst.Domain;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Content { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; } = null!;
}