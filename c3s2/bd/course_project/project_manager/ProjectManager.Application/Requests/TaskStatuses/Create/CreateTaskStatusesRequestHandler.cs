using MediatR;
using ProjectManager.Application.Services;
using TaskStatus = ProjectManager.Domain.TaskStatus;

namespace ProjectManager.Application.Requests.TaskStatuses.Create;

public class CreateTaskStatusesRequestHandler(ITaskStatusRepository _taskStatusRepository) : IRequestHandler<CreateTaskStatusesRequest, TaskStatus>
{
    public async Task<TaskStatus> Handle(CreateTaskStatusesRequest request, CancellationToken cancellationToken)
    {
        var taskStatus = new TaskStatus
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Color = request.Color,
            Staging = request.Staging,
        };
        
        await _taskStatusRepository.CreateAsync(taskStatus);
        await _taskStatusRepository.SaveChangesAsync();
        
        return taskStatus;
    }
}