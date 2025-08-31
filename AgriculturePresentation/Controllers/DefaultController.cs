using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class DefaultController : Controller
{
    
    ServicesManager servicesManager = new ServicesManager(new EfServiceDal());
    // GET
    public IActionResult Index()
    {
        var values  = servicesManager.GetAll();
        return View(values);
    }
}