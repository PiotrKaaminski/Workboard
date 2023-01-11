using Workboard.Models.Task;

namespace Core.Domain.Task.Services;

public interface IModifyTaskService
{
    public void ModifyTask(ModifyTaskRequestModel modifiedTask);
}