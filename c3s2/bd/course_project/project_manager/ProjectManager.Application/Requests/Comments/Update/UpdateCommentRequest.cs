using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Comments.Update;

public class UpdateCommentRequest : IRequest<Comment>
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
}