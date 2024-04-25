using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Requests.Teams.Delete;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TeamTasks.Delete;

public class DelteTeamTaskRequestHandler(ITeamTaskRepository _teamTaskRepository) : IRequestHandler<DeleteTeamTaskRequest>
{
    public async Task Handle(DeleteTeamTaskRequest request, CancellationToken cancellationToken)
    {
        var teamTask = await Predicates.Repositories<TeamTask>.ThrowIfNullFromPredicateAsync(_teamTaskRepository, Predicates.TeamTasks.GetById(request.Id));
        
        _teamTaskRepository.Delete(teamTask);
        
        await _teamTaskRepository.SaveChangesAsync();
    }
}