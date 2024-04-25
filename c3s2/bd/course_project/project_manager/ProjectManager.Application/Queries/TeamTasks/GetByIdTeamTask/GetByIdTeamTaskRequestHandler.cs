using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.TeamTasks.GetByIdTeamTask;

public class GetByIdTeamTaskRequestHandler(ITeamTaskRepository _teamTaskRepository) : IRequestHandler<GetByIdTeamTaskRequest, TeamTask>
{
    public Task<TeamTask> Handle(GetByIdTeamTaskRequest request, CancellationToken cancellationToken)
    {
        return Predicates.Repositories<TeamTask>.ThrowIfNullFromPredicateAsync(
            _teamTaskRepository,
            Predicates.TeamTasks.GetById(request.Id));
    }
}