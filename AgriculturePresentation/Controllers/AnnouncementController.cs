using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class AnnouncementController : Controller
{
    private readonly IAnnouncementsService _announcementsService;
    
    public AnnouncementController(IAnnouncementsService announcementsService)
    {
        _announcementsService = announcementsService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _announcementsService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddAnnouncement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddAnnouncement(Announcements p)
    {
        p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
        p.Status = true;
        _announcementsService.Insert(p);
        return RedirectToAction("Index");
    }
    
    public IActionResult DeleteAnnouncement(int id)
    {
        var values = _announcementsService.GetById(id);
        _announcementsService.Delete(values);
        return RedirectToAction("Index"); 
    }
    
    [HttpGet]
    public IActionResult UpdateAnnouncement(int id)
    {
        var values = _announcementsService.GetById(id);
        return View(values);   
    }
    
    [HttpPost]
    public IActionResult UpdateAnnouncement(Announcements p)
    {
        _announcementsService.Update(p);
        return RedirectToAction("Index");  
    }
}