using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;
using TaskStatus = ProjectManager.Domain.TaskStatus;

namespace ProjectManager.Application.Requests.TeamTasks.ChangeTaskStatus;

public class ChangeTaskStatusRequestHandler(
    ITeamTaskRepository _teamTaskRepository,
    ITaskStatusRepository _taskStatusRepository) : IRequestHandler<ChangeTaskStatusRequest, TeamTask>
{
    public async Task<TeamTask> Handle(ChangeTaskStatusRequest request, CancellationToken cancellationToken)
    {
        var teamTask = await Predicates.Repositories<TeamTask>.ThrowIfNullFromPredicateAsync(_teamTaskRepository, Predicates.TeamTasks.GetById(request.TaskId));
        var taskStatus = await Predicates.Repositories<TaskStatus>.ThrowIfNullFromPredicateAsync(_taskStatusRepository, Predicates.TaskStatuses.GetById(request.TaskStatusId));
        
        teamTask.TaskStatusId = taskStatus.Id;
        
        await _teamTaskRepository.UpdateAsync(teamTask);
        await _teamTaskRepository.SaveChangesAsync();

        return teamTask;
    }
}