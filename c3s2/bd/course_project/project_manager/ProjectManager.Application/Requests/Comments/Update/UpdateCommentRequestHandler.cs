using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Comments.Update;

public class UpdateCommentRequestHandler(ICommentRepository _commentRepository) : IRequestHandler<UpdateCommentRequest, Comment>
{
    public async Task<Comment> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await Predicates.Repositories<Comment>.ThrowIfNullFromPredicateAsync(_commentRepository, Predicates.Comments.GetById(request.Id));
        
        comment.Text = request.Text;
        
        await _commentRepository.UpdateAsync(comment);
        await _commentRepository.SaveChangesAsync();

        return comment;
    }
}