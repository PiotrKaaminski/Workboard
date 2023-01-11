using Workboard.Models.Task;

namespace Core.Domain.Task.Services;

public interface IAddTaskService
{
    public void AddTask(AddTaskRequestModel newTask);
}