using DataAccess.Abstract;
using DataAccess.Concrate.Repository;
using Entity;

namespace DataAccess.Concrate.EntityFramework;

public class EfSocialMediaDal:GenericRepository<SocialMedia>,ISocialMediaDal
{
    
}