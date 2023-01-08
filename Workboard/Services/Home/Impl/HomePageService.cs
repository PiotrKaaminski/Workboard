using Workboard.Context;
using Workboard.Models;

namespace Workboard.Services.Impl;

public class HomePageService : IHomePageService
{

    private readonly WorkboardDbContext _dbContext = new();
    
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