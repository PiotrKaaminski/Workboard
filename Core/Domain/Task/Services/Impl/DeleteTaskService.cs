using Workboard.Context;

namespace Core.Domain.Task.Services.Impl;

public class DeleteTaskService : IDeleteTaskService
{
    
    private readonly WorkboardDbContext _dbContext = new();
    
    public void DeleteTaskById(long id)
    {
        _dbContext.Tasks.Remove(_dbContext.Tasks.Find(id));
        _dbContext.SaveChanges();
    }
}