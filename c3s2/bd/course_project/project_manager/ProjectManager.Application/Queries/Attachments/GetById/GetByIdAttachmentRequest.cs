using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Attachments.GetById;

public class GetByIdAttachmentRequest : IRequest<Attachment>
{
    public Guid Id { get; set; }
}