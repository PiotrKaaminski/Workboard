using Workboard.Context;
using Workboard.Models.Task;

namespace Core.Domain.Task.Services.Impl;

public class AddTaskService : IAddTaskService
{

    private readonly WorkboardDbContext _dbContext = new();
    
    public void AddTask(TaskDto newTask)
    {
        var taskEntity = new Workboard.Entities.Task();
        taskEntity.Title = newTask.Title;
        taskEntity.Description = newTask.Description;
        taskEntity.StatusId = (int) newTask.StatusId;
        _dbContext.Tasks.Add(taskEntity);
        _dbContext.SaveChanges();
    }
    
}