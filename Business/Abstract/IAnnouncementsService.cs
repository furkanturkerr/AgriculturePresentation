using Entity.Concrate;

namespace Business.Abstract;

public interface IAnnouncementsService : IGenericService<Announcements>
{
    void AnnouncementsStatusToTrue(int id);
    void AnnouncementsStatusToFalse(int id);
}