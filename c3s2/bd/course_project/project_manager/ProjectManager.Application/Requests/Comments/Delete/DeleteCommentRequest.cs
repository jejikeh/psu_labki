using MediatR;

namespace ProjectManager.Application.Requests.Comments.Delete;

public class DeleteCommentRequest : IRequest
{
    public Guid Id { get; set; }
}