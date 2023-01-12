using Workboard.Models;
using Workboard.Models.Home;
using Workboard.Models.Task;

namespace Workboard.Services;

public interface IHomeServiceAdapter
{
    public Dictionary<TaskStatusEnum, List<BaseTaskModel>> GetTasksByStatus();
}