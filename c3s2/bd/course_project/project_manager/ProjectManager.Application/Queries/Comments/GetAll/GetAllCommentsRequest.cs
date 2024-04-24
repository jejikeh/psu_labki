using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Comments.GetAll;

public class GetAllCommentsRequest : IRequest<IEnumerable<Comment>>
{
    public Guid AuthorId { get; set; }
    public int Page { get; set; }
    public int Take { get; set; }
}