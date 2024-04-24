using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.FileTypes.Create;

public class CreateFileTypeRequest : IRequest<FileType>
{
    public string Name { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
}