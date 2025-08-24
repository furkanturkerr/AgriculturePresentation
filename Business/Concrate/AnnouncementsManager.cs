using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;

namespace Business.Concrate;

public class AnnouncementsManager : IAnnouncementsService
{
    private readonly IAnnouncementsDal _announcementsDal;
    
    public AnnouncementsManager(IAnnouncementsDal announcementsDal)
    {
        _announcementsDal = announcementsDal;
    }
    
    public void Insert(Announcements t)
    {
        _announcementsDal.Insert(t);       
    }

    public void Update(Announcements t)
    {
        _announcementsDal.Update(t);      
    }

    public void Delete(Announcements t)
    {
       _announcementsDal.Delete(t); 
    }

    public Announcements GetById(int id)
    {
        return _announcementsDal.GetById(id);       
    }

    public List<Announcements> GetAll()
    {
       return _announcementsDal.GetAll();       
    }

    public void AnnouncementsStatusToTrue(int id)
    {
        _announcementsDal.AnnouncementsStatusToTrue(id);
    }

    public void AnnouncementsStatusToFalse(int id)
    {
        _announcementsDal.AnnouncementsStatusToFalse(id);       
    }
}