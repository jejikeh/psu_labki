using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.ProjectStages.Delete;

public class DeleteProjectStageRequest : IRequest
{
    public Guid Id { get; set; }
}