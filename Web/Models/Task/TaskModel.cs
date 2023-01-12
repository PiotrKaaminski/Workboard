namespace Workboard.Models.Task;

public class TaskModel
{
    public readonly long Id;
    public readonly string Title;
    public readonly string Description;
    public readonly TaskStatusEnum Status;
    public readonly long StatusId;

    public TaskModel(long id, string title, string description, TaskStatusEnum status, long statusId)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        StatusId = statusId;
    }
}