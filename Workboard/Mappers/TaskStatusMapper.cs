using Workboard.Models;

namespace Workboard.Mappers;

public class TaskStatusMapper
{
    public static string MapTaskStatusToString(TaskStatusEnum status)
    {
        switch (status)
        {
            case TaskStatusEnum.Backlog:
                return "Backlog";
            case TaskStatusEnum.InProgress:
                return "In progress";
            case TaskStatusEnum.InReview:
                return "In review";
            case TaskStatusEnum.WaitingForDeployment:
                return "Waiting for deployment";
            case TaskStatusEnum.TestsInProgress:
                return "Tests in progress";
            case TaskStatusEnum.Done:
                return "Done";
            default:
                return "Undefined";
        }
    }
}