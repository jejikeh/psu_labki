using MediatR;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TaskTags.Create;

public class CreateTaskTagRequestHandler(ITaskTagsRepository _taskTagsRepository) : IRequestHandler<CreateTaskTagRequest, TaskTag>
{
    public async Task<TaskTag> Handle(CreateTaskTagRequest request, CancellationToken cancellationToken)
    {
        var taskTag = new TaskTag
        {
            Id = Guid.NewGuid(),
            Tag = request.Tag,
            TaskId = request.TaskId
        };
        
        await _taskTagsRepository.CreateAsync(taskTag);
        await _taskTagsRepository.SaveChangesAsync();
        
        return taskTag;
    }
}