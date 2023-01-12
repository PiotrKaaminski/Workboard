namespace Workboard.Models.Task;

public class BaseTaskDto
{
    public readonly long Id;
    public readonly string Title;

    public BaseTaskDto(long id, string title)
    {
        Id = id;
        Title = title;
    }
}