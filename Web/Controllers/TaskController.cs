using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Workboard.Models;
using Workboard.Models.Task;
using Workboard.Services.Task;
using Workboard.Services.TaskStatus;

namespace Workboard.Controllers;

public class TaskController : Controller
{

    private readonly ITaskStatusService _taskStatusService;
    private readonly ITaskService _taskService;

    public TaskController(ITaskStatusService taskStatusService, ITaskService taskService)
    {
        _taskStatusService = taskStatusService;
        _taskService = taskService;
    }
    
    public IActionResult ViewTask(long id)
    {
        ViewBag.Task = _taskService.GetTaskById(id);
        return View();
    }

    public IActionResult AddTask()
    {
        ViewBag.TaskStatuses = _taskStatusService.GetStatuses();
        return View();
    }
    
    [HttpPost]
    public IActionResult AddTask(AddTaskRequestModel newTask)
    {
        _taskService.AddTask(newTask);
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult DeleteTask(long id)
    {
        ViewBag.Task = _taskService.GetTaskById(id);
        return View();
    }
    
    public IActionResult ConfirmDeleteTask(long id)
    {
        _taskService.DeleteTaskById(id);
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult ModifyTask(long id)
    {
        ViewBag.Task = _taskService.GetTaskById(id);
        ViewBag.TaskStatuses = _taskStatusService.GetStatuses();
        return View();
    }
    
    [HttpPost]
    public IActionResult ModifyTask(ModifyTaskRequestModel modifiedTask)
    {
        _taskService.ModifyTask(modifiedTask);
        return RedirectToAction("Index", "Home");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}