namespace Workboard.Models.Task;

public class AddTaskRequestModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string TaskStatusId { get; set; }
}