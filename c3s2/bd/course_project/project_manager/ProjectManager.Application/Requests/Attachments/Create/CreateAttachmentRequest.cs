using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Attachments.Create;

public class CreateAttachmentRequest : IRequest<Attachment>
{
    public Guid AuthorId { get; set; }
    public string Extension { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}