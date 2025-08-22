using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class ImageController1 : Controller
{
    private readonly IImagesService _imagesService;
    
    public ImageController1(IImagesService imagesService)
    {
        _imagesService = imagesService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _imagesService.GetAll();
        return View();
    }
}