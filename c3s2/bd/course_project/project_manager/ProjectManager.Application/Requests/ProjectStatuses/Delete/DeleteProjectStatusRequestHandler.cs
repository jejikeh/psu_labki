using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.ProjectStatuses.Delete;

public class DeleteProjectStatusRequestHandler(IProjectStatusRepository _projectStatusRepository) : IRequestHandler<DeleteProjectStatusRequest>
{
    public async Task Handle(DeleteProjectStatusRequest request, CancellationToken cancellationToken)
    {
        var projectStatus = await Predicates.Repositories<ProjectStatus>.ThrowIfNullFromPredicateAsync(
            _projectStatusRepository,
            Predicates.ProjectStatuses.GetById(request.Id));
        
        _projectStatusRepository.Delete(projectStatus);
        
        await _projectStatusRepository.SaveChangesAsync();
    }
}