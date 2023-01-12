using Workboard.Models.Task;

namespace Workboard.Services.TaskStatus;

public interface ITaskStatusService
{
    public List<TaskStatusDto> GetStatuses();
    
}