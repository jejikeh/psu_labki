using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Comments.Delete;

public class DeleteCommentRequestHandler(ICommentRepository _commentRepository) : IRequestHandler<DeleteCommentRequest>
{
    public async Task Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await Predicates.Repositories<Comment>.ThrowIfNullFromPredicateAsync(
            _commentRepository, 
            Predicates.Comments.GetById(request.Id));
        
        _commentRepository.Delete(comment);
        
        await _commentRepository.SaveChangesAsync();
    }
}