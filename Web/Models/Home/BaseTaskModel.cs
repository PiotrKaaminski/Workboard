namespace Workboard.Models.Home;

public class BaseTaskModel
{
    public readonly long Id;
    public readonly string Title;

    public BaseTaskModel(long id, string title)
    {
        Id = id;
        Title = title;
    }
}