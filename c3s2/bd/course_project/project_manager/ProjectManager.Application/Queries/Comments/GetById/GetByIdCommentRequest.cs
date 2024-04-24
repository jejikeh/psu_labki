using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Comments.GetById;

public class GetByIdCommentRequest : IRequest<Comment>
{
    public Guid Id { get; set; }
}