using Business.Abstract;
using DataAccess.Abstract;
using Entity;

namespace Business.Concrate;

public class SocialMediaManager:ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;
    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }
    public void Insert(SocialMedia t)
    {
       _socialMediaDal.Insert(t);
    }

    public void Update(SocialMedia t)
    {
        _socialMediaDal.Update(t);      
    }

    public void Delete(SocialMedia t)
    {
        _socialMediaDal.Delete(t);
    }

    public SocialMedia GetById(int id)
    {
        return _socialMediaDal.GetById(id);      
    }

    public List<SocialMedia> GetAll()
    {
        return _socialMediaDal.GetAll();      
    }
}