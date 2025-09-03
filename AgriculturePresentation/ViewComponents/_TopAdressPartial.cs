using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents;

public class _TopAdressPartial:  ViewComponent
{
    private readonly IAddressService _addressService;

    public _TopAdressPartial(IAddressService addressService)
    {
        _addressService = addressService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _addressService.GetAll();
        return View(values);
    }
}