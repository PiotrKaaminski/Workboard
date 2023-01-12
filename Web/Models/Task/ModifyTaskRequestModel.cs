namespace Workboard.Models.Task;

public class ModifyTaskRequestModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string TaskStatusId { get; set; }
}