using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Comments.Create;

public class CreateCommentRequest : IRequest<Comment>
{
    public Guid AuthorId { get; set; }
    public string Text { get; set; } = string.Empty;
}