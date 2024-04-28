using MediatR;

namespace ProjectManager.Application.Requests.ProjectStages.Delete;

public class DeleteProjectStageRequestHandler : IRequestHandler<DeleteProjectStageRequest>
{
    public Task Handle(DeleteProjectStageRequest request, CancellationToken cancellationToken)
    {
        
    }
}