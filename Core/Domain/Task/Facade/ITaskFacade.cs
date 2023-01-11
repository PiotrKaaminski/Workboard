using Workboard.Models;
using Workboard.Models.Task;

namespace Workboard.Services.Task;

public interface ITaskFacade
{
    public void AddTask(AddTaskRequestModel newTask);
    TaskModel GetTaskById(long id);
    void DeleteTaskById(long id);
    void ModifyTask(ModifyTaskRequestModel modifiedTask);
    public Dictionary<TaskStatusEnum, List<TaskBaseModel>> GetTasksByStatus();
}