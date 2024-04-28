using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.ProjectStages.Create;

public class CreateProjectStagesRequest : IRequest<ProjectStage>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Guid ProjectId { get; set; }
}