using Workboard.Models.Task;

namespace Workboard.Services.Task;

public interface ITaskService
{
    public void AddTask(AddTaskRequestModel newTask);
    TaskModel GetTaskById(long id);
    void DeleteTaskById(long id);
    void ModifyTask(ModifyTaskRequestModel modifiedTask);
}