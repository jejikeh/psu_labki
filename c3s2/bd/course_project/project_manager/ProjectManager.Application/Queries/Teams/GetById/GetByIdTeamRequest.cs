using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Queries.Teams.GetById;

public class GetByIdTeamRequest : IRequest<Team>
{
    public Guid Id { get; set; }
}