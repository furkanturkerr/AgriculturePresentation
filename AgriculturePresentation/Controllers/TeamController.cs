using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class TeamController : Controller
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public IActionResult Index()
    {
        var values = _teamService.GetAll();
    
        if (values == null || !values.Any())
        {
            ViewBag.Message = "Henüz ekip üyesi bulunmamaktadır.";
            values = new List<Team>(); 
        }
    
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddTeam()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddTeam(Team team)
    {
        _teamService.Insert(team);
        return RedirectToAction("Index");
    }

}