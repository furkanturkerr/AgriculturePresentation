using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class DefaultController : Controller
{
    private readonly IContactService _contactService;
    public DefaultController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public PartialViewResult SendMessage()
    {
        return PartialView();
    }
    
    [HttpPost]
    public IActionResult SendMessage(Contact contact)
    {
        contact.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
        _contactService.Insert(contact);
        return RedirectToAction("Index", "Default");
    }
}