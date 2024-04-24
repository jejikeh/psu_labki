using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Attachments.Create;

public class CreateAttachmentRequestHandler(
    IAttachmentRepository _attachmentRepository, 
    IFileTypeRepository _fileTypeRepository,
    IUserRepository _userRepository) 
    : IRequestHandler<CreateAttachmentRequest, Attachment>
{
    public async Task<Attachment> Handle(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        var attachment = new Attachment
        {
            Id = Guid.NewGuid(),
            AuthorId = (await Predicates.Repositories<User>.ThrowIfNullFromPredicateAsync(_userRepository, Predicates.Users.GetById(request.AuthorId))).Id,
            FileTypeId = (await Predicates.Repositories<FileType>.ThrowIfNullFromPredicateAsync(_fileTypeRepository, Predicates.FileTypes.GetByExtension(request.Extension))).Id,
            Content = request.Content
        };
        
        await _attachmentRepository.CreateAsync(attachment);
        await _attachmentRepository.SaveChangesAsync();
        
        return attachment;
    }
}