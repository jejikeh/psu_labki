using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.FileTypes.GetById;

public class GetByIdFileTypeRequest : IRequest<FileType>
{
    public Guid Id { get; set; }
}