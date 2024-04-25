using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Teams.Delete;

public class DeleteTeamRequestHandler(ITeamRepository _teamRepository) : IRequestHandler<DeleteTeamRequest>
{
    public async Task Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await Predicates.Repositories<Team>.ThrowIfNullFromPredicateAsync(
            _teamRepository, 
            Predicates.Teams.GetById(request.Id));
        
        _teamRepository.Delete(team);
        
        await _teamRepository.SaveChangesAsync();
    }
}