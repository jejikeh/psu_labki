using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.ProjectStatuses.Create;

public class CreateProjectStatusRequestHandler(IProjectStatusRepository _projectStatusRepository) : IRequestHandler<CreateProjectStatusRequest, ProjectStatus>
{
    public async Task<ProjectStatus> Handle(CreateProjectStatusRequest request, CancellationToken cancellationToken)
    {
        var projectStatus = new ProjectStatus
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await _projectStatusRepository.CreateAsync(projectStatus);
        await _projectStatusRepository.SaveChangesAsync();

        return projectStatus;
    }
}