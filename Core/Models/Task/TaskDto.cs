namespace Workboard.Models.Task;

public class TaskDto
{
    public readonly long Id;
    public readonly string Title;
    public readonly string Description;
    public readonly TaskStatusEnum Status;
    public readonly long StatusId;

    public TaskDto(long id, string title, string description, TaskStatusEnum status, int statusId)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        StatusId = statusId;
    }
}