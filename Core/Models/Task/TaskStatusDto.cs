namespace Workboard.Models.Task;

public class TaskStatusDto
{
    public readonly long Id;
    public readonly TaskStatusEnum Status;

    public TaskStatusDto(long id, TaskStatusEnum status)
    {
        Id = id;
        Status = status;
    }
}