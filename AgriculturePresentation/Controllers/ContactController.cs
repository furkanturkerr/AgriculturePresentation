using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _contactService.GetAll();
        return View(values);
    }
    
    public IActionResult DeleteMessage(int id)
    {
        var values = _contactService.GetById(id);
        _contactService.Delete(values);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult MessageDetailes(int id)
    {
        var values = _contactService.GetById(id);
        return View(values);
    }
}