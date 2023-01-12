using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Workboard.Models;
using Workboard.Models.Task;
using Workboard.Services;
using Workboard.Services.Task;
using Workboard.Services.TaskStatus;

namespace Workboard.Controllers;

public class TaskController : Controller
{

    private readonly ITaskServiceAdapter _taskServiceAdapter;

    public TaskController(ITaskServiceAdapter taskServiceAdapter)
    {
        _taskServiceAdapter = taskServiceAdapter;
    }
    
    public IActionResult ViewTask(long id)
    {
        ViewBag.Task = _taskServiceAdapter.GetTaskById(id);
        return View();
    }

    public IActionResult AddTask()
    {
        ViewBag.TaskStatuses = _taskServiceAdapter.GetStatuses();
        return View();
    }
    
    [HttpPost]
    public IActionResult AddTask(AddTaskRequestModel newTask)
    {
        _taskServiceAdapter.AddTask(newTask);
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult DeleteTask(long id)
    {
        ViewBag.Task = _taskServiceAdapter.GetTaskById(id);
        return View();
    }
    
    public IActionResult ConfirmDeleteTask(long id)
    {
        _taskServiceAdapter.DeleteTaskById(id);
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult ModifyTask(long id)
    {
        ViewBag.Task = _taskServiceAdapter.GetTaskById(id);
        ViewBag.TaskStatuses = _taskServiceAdapter.GetStatuses();
        return View();
    }
    
    [HttpPost]
    public IActionResult ModifyTask(ModifyTaskRequestModel modifiedTask)
    {
        _taskServiceAdapter.ModifyTask(modifiedTask);
        return RedirectToAction("Index", "Home");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}