using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Attachments.GetAll;

public class GetAllAttachmentsRequest : IRequest<IEnumerable<Attachment>>
{
    public Guid AuthorId { get; set; }
    public int Page { get; set; }
    public int Take { get; set; }
}