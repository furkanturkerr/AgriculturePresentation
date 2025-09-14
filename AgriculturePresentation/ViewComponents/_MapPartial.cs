using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents;

public class _MapPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        AgricultureContext aggicultureContext = new AgricultureContext();
        var values = aggicultureContext.Adresses.Select(x => x.MapInfo).FirstOrDefault();
        ViewBag.V = values;
        return View();
    }
}