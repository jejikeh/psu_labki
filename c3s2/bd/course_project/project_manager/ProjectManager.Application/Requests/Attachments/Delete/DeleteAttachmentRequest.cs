using MediatR;

namespace ProjectManager.Application.Requests.Attachments.Delete;

public class DeleteAttachmentRequest : IRequest
{
    public Guid Id { get; set; }
}