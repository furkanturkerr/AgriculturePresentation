using Entity.Concrate;

namespace DataAccess.Abstract;

public interface IAnnouncementsDal:IGenericDal<Announcements>
{
    void AnnouncementsStatusToTrue(int id);
    void AnnouncementsStatusToFalse(int id);
}