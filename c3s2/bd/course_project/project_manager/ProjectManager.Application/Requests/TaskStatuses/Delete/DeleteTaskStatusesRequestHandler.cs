using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using TaskStatus = ProjectManager.Domain.TaskStatus;

namespace ProjectManager.Application.Requests.TaskStatuses.Delete;

public class DeleteTaskStatusesRequestHandler(ITaskStatusRepository _taskStatusRepository) : IRequestHandler<DeleteTaskStatusesRequest>
{
    public async Task Handle(DeleteTaskStatusesRequest request, CancellationToken cancellationToken)
    {
        var taskStatuses = await Predicates.Repositories<TaskStatus>.ThrowIfNullFromPredicateAsync(
            _taskStatusRepository,
            Predicates.TaskStatuses.GetById(request.Id));
        
        _taskStatusRepository.Delete(taskStatuses);
        
        await _taskStatusRepository.SaveChangesAsync();
    }
}