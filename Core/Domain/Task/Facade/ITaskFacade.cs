using Workboard.Models;
using Workboard.Models.Task;

namespace Workboard.Services.Task;

public interface ITaskFacade
{
    public void AddTask(TaskDto newTask);
    TaskDto GetTaskById(long id);
    void DeleteTaskById(long id);
    void ModifyTask(long id, TaskDto modifiedTask);
    public Dictionary<TaskStatusEnum, List<BaseTaskDto>> GetTasksByStatus();
}