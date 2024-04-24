using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.FileTypes.GetById;

public class GetByIdFileTypeRequestHandler(IFileTypeRepository _fileTypeRepository) : IRequestHandler<GetByIdFileTypeRequest, FileType>
{
    public Task<FileType> Handle(GetByIdFileTypeRequest request, CancellationToken cancellationToken)
    {
        return Predicates.Repositories<FileType>.ThrowIfNullFromPredicateAsync(_fileTypeRepository, Predicates.FileTypes.GetById(request.Id));
    }
}