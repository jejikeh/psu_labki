using MediatR;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.Teams.Delete;

public class DeleteTeamRequest : IRequest
{
    public Guid Id { get; set; }
}