using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Teams.Create;

public class CreateTeamRequestHandler(IProjectRepository _projectRepository) : IRequestHandler<CreateTeamRequest, Team>
{
    public async Task<Team> Handle(CreateTeamRequest request, CancellationToken cancellationToken)
    {
        var project = await Predicates.Repositories<Project>.ThrowIfNullFromPredicateAsync(_projectRepository, Predicates.Projects.GetById(request.ProjectId));

        var team = new Team
        {
            Id = Guid.NewGuid(),
            ProjectId = project.Id,
            Name = request.Name,
            Description = request.Description
        };
        
        await _projectRepository.CreateAsync(project);
        await _projectRepository.SaveChangesAsync();
        
        return team;
    }
}