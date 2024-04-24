using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.FileTypes.Create;

public class CreateFileTypeRequestHandler(IFileTypeRepository _fileTypeRepository) : IRequestHandler<CreateFileTypeRequest, FileType>
{
    public async Task<FileType> Handle(CreateFileTypeRequest request, CancellationToken cancellationToken)
    {
        var fileType = new FileType
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Extension = request.Extension
        };
        
        await _fileTypeRepository.CreateAsync(fileType);
        await _fileTypeRepository.SaveChangesAsync();
        
        return fileType;
    }
}