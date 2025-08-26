using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrate;
using FluentValidation.Results;
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
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddImage()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddImage(Image image)
    {
        ImageValidator validationRules = new ImageValidator();
        ValidationResult result = validationRules.Validate(image);
        if (result.IsValid)
        {
            _imagesService.Insert(image);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();   
    }
    
    public IActionResult DeleteImage(int id)
    {
        var values = _imagesService.GetById(id);
        _imagesService.Delete(values);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult UpdateImage(int id)
    {
        var values = _imagesService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult UpdateImage(Image image)
    {
        ImageValidator validationRules = new ImageValidator();
        ValidationResult result = validationRules.Validate(image);
        if (result.IsValid)
        {
            _imagesService.Update(image);
            return RedirectToAction("Index");   
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();   
    }
}