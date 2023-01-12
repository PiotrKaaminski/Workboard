using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Workboard.Models;
using Workboard.Services;
using Workboard.Services.Task;

namespace Workboard.Controllers;

public class HomeController : Controller
{
    private readonly IHomeServiceAdapter _homeServiceAdapter;

    public HomeController(IHomeServiceAdapter homeServiceAdapter)
    {
        _homeServiceAdapter = homeServiceAdapter;
    }

    public IActionResult Index()
    {
        var statusTaskListMap = _homeServiceAdapter.GetTasksByStatus();
        ViewBag.StatusTaskListMap = statusTaskListMap;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}