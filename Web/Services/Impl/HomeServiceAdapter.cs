using Workboard.Models;
using Workboard.Models.Home;
using Workboard.Models.Task;
using Workboard.Services.Task;

namespace Workboard.Services.Impl;

public class HomeServiceAdapter : IHomeServiceAdapter
{

    private readonly ITaskFacade _taskFacade;

    public HomeServiceAdapter(ITaskFacade taskFacade)
    {
        _taskFacade = taskFacade;
    }

    public Dictionary<TaskStatusEnum, List<BaseTaskModel>> GetTasksByStatus()
    {
        var statusColumnMap = _taskFacade.GetTasksByStatus();
        var result = new Dictionary<TaskStatusEnum, List<BaseTaskModel>>();
        foreach (var entry in statusColumnMap)
        {
            var column = entry.Value.ConvertAll(t => new BaseTaskModel(t.Id, t.Title));
            result.Add(entry.Key, column);
        }

        return result;
    }
}