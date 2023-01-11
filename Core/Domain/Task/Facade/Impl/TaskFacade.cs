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

    public void AddTask(AddTaskRequestModel newTask)
    {
        _addTaskService.AddTask(newTask);
    }

    public TaskModel GetTaskById(long id)
    {
        return _getTasksService.GetTaskById(id);
    }

    public void DeleteTaskById(long id)
    {
        _deleteTaskService.DeleteTaskById(id);
    }

    public void ModifyTask(ModifyTaskRequestModel modifiedTask)
    {
        _modifyTaskService.ModifyTask(modifiedTask);
    }

    public Dictionary<TaskStatusEnum, List<TaskBaseModel>> GetTasksByStatus()
    {
        return _getTasksService.GetTasksByStatus();
    }
}