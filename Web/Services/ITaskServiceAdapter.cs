using Workboard.Models.Task;

namespace Workboard.Services;

public interface ITaskServiceAdapter
{
    public List<TaskStatusModel> GetStatuses();
    public TaskModel GetTaskById(long id);
    public void AddTask(AddTaskRequestModel newTask);
    public void DeleteTaskById(long id);
    void ModifyTask(ModifyTaskRequestModel modifiedTask);
}