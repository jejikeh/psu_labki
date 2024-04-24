using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Attachments.Delete;

public class DeleteAttachmentRequestHandler(IAttachmentRepository _attachmentRepository) : IRequestHandler<DeleteAttachmentRequest>
{
    public async Task Handle(DeleteAttachmentRequest request, CancellationToken cancellationToken)
    {
        var attachment = await Predicates.Repositories<Attachment>.ThrowIfNullFromPredicateAsync(
            _attachmentRepository, 
            Predicates.Attachments.GetById(request.Id));
        
        _attachmentRepository.Delete(attachment);
        
        await _attachmentRepository.SaveChangesAsync();
    }
}