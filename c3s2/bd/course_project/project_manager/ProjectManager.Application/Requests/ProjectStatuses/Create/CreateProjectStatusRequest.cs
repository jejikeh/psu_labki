using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.ProjectStatuses.Create;

public class CreateProjectStatusRequest : IRequest<ProjectStatus>
{
    public string Name { get; set; } = string.Empty;
}