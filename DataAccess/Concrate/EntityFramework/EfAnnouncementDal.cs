using DataAccess.Abstract;
using DataAccess.Concrate.Repository;
using DataAccess.Contexts;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework;

public class EfAnnouncementDal:GenericRepository<Announcements>,IAnnouncementsDal
{
    public void AnnouncementsStatusToTrue(int id)
    {
        using var context = new AgricultureContext();
        Announcements p = context.Announcements.Find(id);
        p.Status = true;
        context.SaveChanges();
    }

    public void AnnouncementsStatusToFalse(int id)
    {
        using var context = new AgricultureContext();
        Announcements p = context.Announcements.Find(id);
        p.Status = false;
        context.SaveChanges();
    }
}