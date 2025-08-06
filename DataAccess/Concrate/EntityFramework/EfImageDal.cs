using DataAccess.Abstract;
using DataAccess.Concrate.Repository;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework;

public class EfImageDal:GenericRepository<Image>,IImageDal
{
    
}