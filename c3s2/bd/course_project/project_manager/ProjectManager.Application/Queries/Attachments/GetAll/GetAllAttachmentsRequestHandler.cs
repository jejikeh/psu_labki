using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Attachments.GetAll;

public class GetAllAttachmentsRequestHandler(IAttachmentRepository attachmentRepository) : IRequestHandler<GetAllAttachmentsRequest, IEnumerable<Attachment>>
{
    public Task<IEnumerable<Attachment>> Handle(GetAllAttachmentsRequest request, CancellationToken cancellationToken)
    {
        return attachmentRepository.GetAllByPredicateAsync(
            attachment => attachment.AuthorId == request.AuthorId, 
            request.Page * request.Take, 
            request.Take);
    }
}