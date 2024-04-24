using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Comments.GetAll;

public class GetAllCommentRequestHandler(ICommentRepository _commentRepository) : IRequestHandler<GetAllCommentsRequest, IEnumerable<Comment>>
{
    public Task<IEnumerable<Comment>> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
    {
        return _commentRepository.GetAllAsync(request.Page * request.Take, request.Take);
    }
}