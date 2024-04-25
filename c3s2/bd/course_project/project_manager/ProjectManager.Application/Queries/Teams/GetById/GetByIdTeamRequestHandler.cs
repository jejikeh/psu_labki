using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Teams.GetById;

public class GetByIdTeamRequestHandler(ITeamRepository _teamRepository) : IRequestHandler<GetByIdTeamRequest, Team>
{
    public Task<Team> Handle(GetByIdTeamRequest request, CancellationToken cancellationToken)
    {
        return Predicates.Repositories<Team>.ThrowIfNullFromPredicateAsync(
            _teamRepository, 
            Predicates.Teams.GetById(request.Id));
    }
}