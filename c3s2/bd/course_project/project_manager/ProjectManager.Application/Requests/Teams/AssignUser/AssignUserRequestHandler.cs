using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Teams.AssignUser;

public class AssignUserRequestHandler(
    ITeamRepository _teamRepository, 
    IUserTeamsRepository _userTeamsRepository,
    IUserRepository _userRepository) : IRequestHandler<AssignUserRequest, Team>
{
    public async Task<Team> Handle(AssignUserRequest request, CancellationToken cancellationToken)
    {
        var team = await Predicates.Repositories<Team>.ThrowIfNullFromPredicateAsync(_teamRepository, Predicates.Teams.GetById(request.TeamId));
        var user = await Predicates.Repositories<User>.ThrowIfNullFromPredicateAsync(_userRepository, Predicates.Users.GetById(request.UserId));

        var userTeam = new UserTeams
        {
            UserId = user.Id,
            TeamId = team.Id,
        };
        
        await _userTeamsRepository.CreateAsync(userTeam);
        await _userTeamsRepository.SaveChangesAsync();
        
        return team;
    }
}