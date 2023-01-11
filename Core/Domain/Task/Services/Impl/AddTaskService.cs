using Workboard.Context;
using Workboard.Models.Task;

namespace Core.Domain.Task.Services.Impl;

public class AddTaskService : IAddTaskService
{
    
    private readonly WorkboardDbContext _dbContext = WorkboardDbContext.Instance; 
    
    public void AddTask(AddTaskRequestModel newTask)
    {
        var taskEntity = new Workboard.Entities.Task();
        taskEntity.Title = newTask.Title;
        taskEntity.Description = newTask.Description;
        taskEntity.StatusId = int.Parse(newTask.TaskStatusId);
        _dbContext.Tasks.Add(taskEntity);
        _dbContext.SaveChanges();
    }
    
}