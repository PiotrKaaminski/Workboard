using Core.Domain.Task.Services;
using Workboard.Models;
using Workboard.Models.Task;

namespace Workboard.Services.Task.Impl;

public class TaskFacade : ITaskFacade
{

    private readonly IAddTaskService _addTaskService;
    private readonly IDeleteTaskService _deleteTaskService;
    private readonly IGetTasksService _getTasksService;
    private readonly IModifyTaskService _modifyTaskService;

    public TaskFacade(IAddTaskService addTaskService, IDeleteTaskService deleteTaskService, IGetTasksService getTasksService, IModifyTaskService modifyTaskService)
    {
        _addTaskService = addTaskService;
        _deleteTaskService = deleteTaskService;
        _getTasksService = getTasksService;
        _modifyTaskService = modifyTaskService;
    }

    public void AddTask(TaskDto newTask)
    {
        _addTaskService.AddTask(newTask);
    }

    public TaskDto GetTaskById(long id)
    {
        return _getTasksService.GetTaskById(id);
    }

    public void DeleteTaskById(long id)
    {
        _deleteTaskService.DeleteTaskById(id);
    }

    public void ModifyTask(long id, TaskDto modifiedTask)
    {
        _modifyTaskService.ModifyTask(id, modifiedTask);
    }

    public Dictionary<TaskStatusEnum, List<BaseTaskDto>> GetTasksByStatus()
    {
        return _getTasksService.GetTasksByStatus();
    }
}