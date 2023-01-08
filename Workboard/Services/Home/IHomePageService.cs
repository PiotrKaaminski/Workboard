using Workboard.Models;

namespace Workboard.Services;

public interface IHomePageService
{
    public Dictionary<TaskStatusEnum, List<TaskBaseModel>> GetTasksByStatus();
}