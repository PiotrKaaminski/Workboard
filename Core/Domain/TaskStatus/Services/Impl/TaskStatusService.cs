using Workboard.Context;
using Workboard.Models;
using Workboard.Models.Task;

namespace Workboard.Services.TaskStatus.Impl;

public class TaskStatusService : ITaskStatusService
{

    private readonly WorkboardDbContext _dbContext = WorkboardDbContext.Instance;

    public List<TaskStatusDto> GetStatuses()
    {
        var statusEntities = _dbContext.TaskStatuses.OrderBy(s => s.Id);
        var result = new List<TaskStatusDto>();
        foreach (var statusEntity in statusEntities)
        {
            Enum.TryParse(statusEntity.Name, true, out TaskStatusEnum statusEnum);
            result.Add(new TaskStatusDto(statusEntity.Id, statusEnum));
        }
        return result;
    }
}