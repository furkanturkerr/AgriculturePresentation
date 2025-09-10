using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents;

public class _GaleryPartial:ViewComponent
{
    private readonly IImagesService _imagesService;
    public _GaleryPartial(IImagesService imagesService)
    {
        _imagesService = imagesService;
    }
    public IViewComponentResult Invoke()
    {
        var values = _imagesService.GetAll();
        return View(values);
    }
}