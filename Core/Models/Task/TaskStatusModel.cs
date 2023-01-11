namespace Workboard.Models.Task;

public class TaskStatusModel
{
    public readonly long Id;
    public readonly TaskStatusEnum Status;

    public TaskStatusModel(long id, TaskStatusEnum status)
    {
        Id = id;
        Status = status;
    }
}