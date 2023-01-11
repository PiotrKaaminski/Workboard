namespace Workboard.Models;

public class TaskBaseModel
{
    public readonly long Id;
    public readonly string Title;

    public TaskBaseModel(long id, string title)
    {
        Id = id;
        Title = title;
    }
}