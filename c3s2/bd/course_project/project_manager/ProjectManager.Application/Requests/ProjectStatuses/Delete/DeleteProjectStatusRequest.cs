using MediatR;

namespace ProjectManager.Application.Requests.ProjectStatuses.Delete;

public class DeleteProjectStatusRequest : IRequest
{
    public Guid Id { get; set; }
}