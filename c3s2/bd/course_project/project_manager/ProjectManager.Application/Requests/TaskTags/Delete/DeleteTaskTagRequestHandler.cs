using MediatR;
using ProjectManager.Application.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Requests.TaskTags.Delete;

public class DeleteTaskTagRequestHandler(ITaskTagsRepository _taskTagsRepository) : IRequestHandler<DeleteTaskTagRequest>
{
    public async Task Handle(DeleteTaskTagRequest request, CancellationToken cancellationToken)
    {
        var taskTag = await Predicates.Repositories<TaskTag>.ThrowIfNullFromPredicateAsync(
            _taskTagsRepository, 
            Predicates.TasksTags.GetById(request.Id));
        
        _taskTagsRepository.Delete(taskTag);
        await _taskTagsRepository.SaveChangesAsync();
    }
}