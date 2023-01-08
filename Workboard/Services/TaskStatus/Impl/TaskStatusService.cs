using Workboard.Context;
using Workboard.Models;
using Workboard.Models.Task;

namespace Workboard.Services.TaskStatus.Impl;

public class TaskStatusService : ITaskStatusService
{

    private readonly WorkboardDbContext _dbContext = new();

    public List<TaskStatusModel> GetStatuses()
    {
        var statusEntities = _dbContext.TaskStatuses.OrderBy(s => s.Id);
        var result = new List<TaskStatusModel>();
        foreach (var statusEntity in statusEntities)
        {
            Enum.TryParse(statusEntity.Name, true, out TaskStatusEnum statusEnum);
            result.Add(new TaskStatusModel(statusEntity.Id, statusEnum));
        }
        return result;
    }
}