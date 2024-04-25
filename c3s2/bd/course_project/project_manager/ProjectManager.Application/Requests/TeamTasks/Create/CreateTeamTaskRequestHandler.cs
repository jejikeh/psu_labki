using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TeamTasks.Create;

public class CreateTeamTaskRequestHandler(ITeamTaskRepository _teamTaskRepository) : IRequestHandler<CreateTeamTaskRequest, TeamTask>
{
    public async Task<TeamTask> Handle(CreateTeamTaskRequest request, CancellationToken cancellationToken)
    {
        var teamTask = new TeamTask
        {
            Id = Guid.NewGuid(),
            TeamId = request.TeamId,
            Name = request.Name,
            Description = request.Description,
            TaskStatusId = request.TaskStatusId,
        };

        await _teamTaskRepository.CreateAsync(teamTask);
        await _teamTaskRepository.SaveChangesAsync();
        
        return teamTask;
    }
}