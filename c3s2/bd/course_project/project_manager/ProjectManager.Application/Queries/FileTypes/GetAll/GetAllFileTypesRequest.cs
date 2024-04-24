using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.FileTypes.GetAll;

public class GetAllFileTypesRequest : IRequest<IEnumerable<FileType>>
{
    public int Page { get; set; }
    public int Take { get; set; }
}