using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class AddressController : Controller
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _addressService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult UpdateAddress(int id)
    {
        var values = _addressService.GetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult UpdateAddress(Adress adress)
    {
        AddressValidation adressValidation = new AddressValidation();
        ValidationResult result = adressValidation.Validate(adress);
        if (result.IsValid)
        {
            _addressService.Update(adress);
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