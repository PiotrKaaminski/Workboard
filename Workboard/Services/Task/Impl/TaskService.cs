using Microsoft.EntityFrameworkCore;
using Workboard.Context;
using Workboard.Models;
using Workboard.Models.Task;

namespace Workboard.Services.Task.Impl;

public class TaskService : ITaskService
{
    
    private readonly WorkboardDbContext _dbContext = new();
    
    public void AddTask(AddTaskRequestModel newTask)
    {
        var taskEntity = new Entities.Task();
        taskEntity.Title = newTask.Title;
        taskEntity.Description = newTask.Description;
        taskEntity.StatusId = int.Parse(newTask.TaskStatusId);
        _dbContext.Tasks.Add(taskEntity);
        _dbContext.SaveChanges();
    }

    public TaskModel GetTaskById(long id)
    {
        var task = _dbContext.Tasks.Include(t => t.Status).FirstOrDefault(t => t.Id == id);
        Enum.TryParse(task.Status.Name, true, out TaskStatusEnum statusEnum);
        return new TaskModel(task.Id, task.Title, task.Description, statusEnum, task.Status.Id);
    }

    public void DeleteTaskById(long id)
    {
        _dbContext.Tasks.Remove(_dbContext.Tasks.Find(id));
        _dbContext.SaveChanges();
    }

    public void ModifyTask(ModifyTaskRequestModel modifiedTask)
    {
        var task = _dbContext.Tasks.Include(t => t.Status).FirstOrDefault(t => t.Id == modifiedTask.Id);
        task.Title = modifiedTask.Title;
        task.Description = modifiedTask.Description;
        task.StatusId = int.Parse(modifiedTask.TaskStatusId);
        _dbContext.Tasks.Update(task);
        _dbContext.SaveChanges();
    }
}