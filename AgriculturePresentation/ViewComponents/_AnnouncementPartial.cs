using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents;

public class _AnnouncementPartial:ViewComponent
{
    private readonly IAnnouncementsService _announcementsService;
    public _AnnouncementPartial(IAnnouncementsService announcementsService)
    {
        _announcementsService = announcementsService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _announcementsService.GetAll();
        return View(values);
    }
}