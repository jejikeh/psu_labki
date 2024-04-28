using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.ProjectStages.Create;

public class CreateProjectStagesRequestHandler(IProjectStageRepository _projectStageRepository) : IRequestHandler<CreateProjectStagesRequest, ProjectStage>
{
    public async Task<ProjectStage> Handle(CreateProjectStagesRequest request, CancellationToken cancellationToken)
    {
        var projectStage = new ProjectStage
        {
            Id = Guid.NewGuid(),
            ProjectId = request.ProjectId,
            Name = request.Name,
            Description = request.Description,
            StartDate = DateOnly.FromDateTime(DateTime.Now),
        };
        
        await _projectStageRepository.CreateAsync(projectStage);
        await _projectStageRepository.SaveChangesAsync();

        return projectStage;
    }
}