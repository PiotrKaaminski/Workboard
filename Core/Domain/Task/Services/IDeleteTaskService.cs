namespace Core.Domain.Task.Services;

public interface IDeleteTaskService
{
    public void DeleteTaskById(long id);
}