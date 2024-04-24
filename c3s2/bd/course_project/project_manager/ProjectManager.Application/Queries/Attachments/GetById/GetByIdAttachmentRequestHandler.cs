using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Attachments.GetById;

public class GetByIdAttachmentRequestHandler(IAttachmentRepository _attachmentRepository) : IRequestHandler<GetByIdAttachmentRequest, Attachment>
{
    public Task<Attachment> Handle(GetByIdAttachmentRequest request, CancellationToken cancellationToken)
    {
        return Predicates.Repositories<Attachment>.ThrowIfNullFromPredicateAsync(
            _attachmentRepository,
            Predicates.Attachments.GetById(request.Id)
        );
    }
}