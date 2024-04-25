using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TaskTags.Create;

public class CreateTaskTagRequest : IRequest<TaskTag>
{
    public string Tag { get; set; } = string.Empty;
    public Guid TaskId { get; set; }
}