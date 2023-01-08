using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Workboard.Context;
using Workboard.Entities;
using Workboard.Models;
using Workboard.Services;
using TaskStatus = Workboard.Entities.TaskStatus;

namespace Workboard.Controllers;

public class HomeController : Controller
{
    private readonly IHomePageService _homePageService;

    public HomeController(IHomePageService homePageService)
    {
        _homePageService = homePageService;
    }

    public IActionResult Index()
    {
        var statusTaskListMap = _homePageService.GetTasksByStatus();
        ViewBag.StatusTaskListMap = statusTaskListMap;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}