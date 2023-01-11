using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Workboard.Models;
using Workboard.Services.Task;

namespace Workboard.Controllers;

public class HomeController : Controller
{
    private readonly ITaskService _taskService;

    public HomeController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        var statusTaskListMap = _taskService.GetTasksByStatus();
        ViewBag.StatusTaskListMap = statusTaskListMap;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}