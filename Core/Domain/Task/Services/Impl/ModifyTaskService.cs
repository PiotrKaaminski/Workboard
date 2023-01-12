using Microsoft.EntityFrameworkCore;
using Workboard.Context;
using Workboard.Models.Task;

namespace Core.Domain.Task.Services.Impl;

public class ModifyTaskService : IModifyTaskService
{
    
    private readonly WorkboardDbContext _dbContext = WorkboardDbContext.Instance;
    
    public void ModifyTask(long id, TaskDto modifiedTask)
    {
        var task = _dbContext.Tasks.Include(t => t.Status).FirstOrDefault(t => t.Id == id);
        task.Title = modifiedTask.Title;
        task.Description = modifiedTask.Description;
        task.StatusId = (int) modifiedTask.StatusId;
        _dbContext.Tasks.Update(task);
        _dbContext.SaveChanges();
    }
}