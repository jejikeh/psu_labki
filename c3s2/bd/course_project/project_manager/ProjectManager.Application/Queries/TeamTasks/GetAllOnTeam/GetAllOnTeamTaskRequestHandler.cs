using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.TeamTasks.GetAllOnTeam;

public class GetAllOnTeamTaskRequestHandler(ITeamTaskRepository _teamTaskRepository) : IRequestHandler<GetAllOnTeamTasksRequest, IEnumerable<TeamTask>>
{
    public Task<IEnumerable<TeamTask>> Handle(GetAllOnTeamTasksRequest request, CancellationToken cancellationToken)
    {
        return _teamTaskRepository.GetAllByPredicateAsync(
            Predicates.TeamTasks.GetByTeamId(request.TeamId));
    }
}