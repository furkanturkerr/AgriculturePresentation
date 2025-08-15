using AgriculturePresentation.Models;
using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class ServiceController : Controller
{
    private readonly IServiceService _serviceService;
    
    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }   
    // GET
    public IActionResult Index()
    {
        var values = _serviceService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddService()
    {
        return View(new ServiceAddViewModel());
    }

    [HttpPost]
    public IActionResult AddService(ServiceAddViewModel model)
    {
        if (ModelState.IsValid)
        {
            _serviceService.Insert(new Service()
            {
                Title = model.Title,
                Image = model.Image,
                Description = model.Description
            });
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult DeleteService(int id)
    {
        var values = _serviceService.GetById(id);
        _serviceService.Delete(values);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateService(int id)
    {
        var values = _serviceService.GetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult UpdateService(Service service)
    {
        _serviceService.Update(service);
        return RedirectToAction("Index");
    }

    public IActionResult Deneme()
    {
        return View();
    }
}