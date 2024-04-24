using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Comments.Create;

public class CreateCommentRequestHandler(ICommentRepository _commentRepository) : IRequestHandler<CreateCommentRequest, Comment>
{
    public async Task<Comment> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            AuthorId = request.AuthorId,
            Text = request.Text,
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow)
        };
        
        await _commentRepository.CreateAsync(comment);
        await _commentRepository.SaveChangesAsync();
        
        return comment;
    }
}