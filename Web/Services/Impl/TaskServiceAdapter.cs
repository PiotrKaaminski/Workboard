using Workboard.Models;
using Workboard.Models.Task;
using Workboard.Services.Task;
using Workboard.Services.TaskStatus;

namespace Workboard.Services;

public class TaskServiceAdapter : ITaskServiceAdapter
{
    private readonly ITaskFacade _taskFacade;
    private readonly ITaskStatusService _taskStatusService;

    public TaskServiceAdapter(ITaskFacade taskFacade, ITaskStatusService taskStatusService)
    {
        _taskFacade = taskFacade;
        _taskStatusService = taskStatusService;
    }

    public List<TaskStatusModel> GetStatuses()
    {
        var statuses = _taskStatusService.GetStatuses();
        return statuses.ConvertAll(s => new TaskStatusModel(s.Id, s.Status));
    }

    public TaskModel GetTaskById(long id)
    {
        var task = _taskFacade.GetTaskById(id);
        return new TaskModel(task.Id, task.Title, task.Description, task.Status, task.StatusId);
    }

    public void AddTask(AddTaskRequestModel newTask)
    {
        _taskFacade.AddTask(new TaskDto(0, newTask.Title, newTask.Description, TaskStatusEnum.Backlog, int.Parse(newTask.TaskStatusId)));
    }

    public void DeleteTaskById(long id)
    {
        _taskFacade.DeleteTaskById(id);
    }

    public void ModifyTask(ModifyTaskRequestModel modifiedTask)
    {
        _taskFacade.ModifyTask(
            modifiedTask.Id, 
            new TaskDto(0, modifiedTask.Title, modifiedTask.Description, TaskStatusEnum.Backlog, int.Parse(modifiedTask.TaskStatusId))
            );
    }
}