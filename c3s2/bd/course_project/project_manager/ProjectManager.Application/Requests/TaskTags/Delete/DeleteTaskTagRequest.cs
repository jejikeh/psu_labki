using MediatR;

namespace ProjectManager.Application.Requests.TaskTags.Delete;

public class DeleteTaskTagRequest : IRequest
{
    public Guid Id { get; set; }
}