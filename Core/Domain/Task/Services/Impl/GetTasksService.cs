using Microsoft.EntityFrameworkCore;
using Workboard.Context;
using Workboard.Models;
using Workboard.Models.Task;

namespace Core.Domain.Task.Services.Impl;

public class GetTasksService : IGetTasksService
{
    
    private readonly WorkboardDbContext _dbContext = WorkboardDbContext.Instance;
    
    public TaskModel GetTaskById(long id)
    {
        var task = _dbContext.Tasks.Include(t => t.Status).FirstOrDefault(t => t.Id == id);
        Enum.TryParse(task.Status.Name, true, out TaskStatusEnum statusEnum);
        return new TaskModel(task.Id, task.Title, task.Description, statusEnum, task.Status.Id);
    }
    
    public Dictionary<TaskStatusEnum, List<TaskBaseModel>> GetTasksByStatus()
    {
        var statusTaskListMap = new Dictionary<TaskStatusEnum, List<TaskBaseModel>>();
        var statusEntities = _dbContext.TaskStatuses.ToList();
        foreach (var statusEntity in statusEntities)
        {
            Enum.TryParse(statusEntity.Name, true, out TaskStatusEnum statusEnum);
            var taskList = _dbContext.Tasks
                .Where(t => t.StatusId == statusEntity.Id)
                .Select(taskEntity => new TaskBaseModel(taskEntity.Id, taskEntity.Title)).ToList();
            
            statusTaskListMap.Add(statusEnum, taskList);
        }
        return statusTaskListMap;
    }
}