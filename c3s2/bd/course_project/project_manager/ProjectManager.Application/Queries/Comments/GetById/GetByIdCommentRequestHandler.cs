using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Comments.GetById;

public class GetByIdCommentRequestHandler(ICommentRepository commentRepository) : IRequestHandler<GetByIdCommentRequest, Comment>
{
    public Task<Comment> Handle(GetByIdCommentRequest request, CancellationToken cancellationToken)
    {
        return Predicates.Repositories<Comment>.ThrowIfNullFromPredicateAsync(
            commentRepository, 
            Predicates.Comments.GetById(request.Id));
    }
}