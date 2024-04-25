using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Teams.GetAllOnProject;

public class GetAllOnProjectRequestHandler(ITeamRepository _teamsRepository) : IRequestHandler<GetAllOnProjectRequest, IEnumerable<Team>>
{
    public Task<IEnumerable<Team>> Handle(GetAllOnProjectRequest request, CancellationToken cancellationToken)
    {
        return _teamsRepository.GetAllByPredicateAsync(
            Predicates.Teams.GetByProjectId(request.ProjectId),
            request.Page * request.Take,
            request.Take);
    }
}