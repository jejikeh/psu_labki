using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.FileTypes.GetAll;

public class GetAllFileTypesRequestHandler(IFileTypeRepository _fileTypeRepository) : IRequestHandler<GetAllFileTypesRequest, IEnumerable<FileType>>
{
    public Task<IEnumerable<FileType>> Handle(GetAllFileTypesRequest request, CancellationToken cancellationToken)
    {
        var fileTypes = _fileTypeRepository.GetAllAsync(request.Page * request.Take, request.Take);
        
        return fileTypes;
    }
}