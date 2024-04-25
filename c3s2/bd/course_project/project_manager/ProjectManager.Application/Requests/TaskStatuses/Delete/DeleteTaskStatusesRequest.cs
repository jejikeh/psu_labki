using MediatR;

namespace ProjectManager.Application.Requests.TaskStatuses.Delete;

public class DeleteTaskStatusesRequest : IRequest
{
    public Guid Id { get; set; }
}