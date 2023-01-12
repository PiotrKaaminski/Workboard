using Workboard.Models;
using Workboard.Models.Task;

namespace Core.Domain.Task.Services;

public interface IGetTasksService
{
    public TaskDto GetTaskById(long id);
    public Dictionary<TaskStatusEnum, List<BaseTaskDto>> GetTasksByStatus();
}