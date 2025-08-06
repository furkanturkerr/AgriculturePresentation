using DataAccess.Abstract;
using DataAccess.Concrate.Repository;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework;

public class EfServiceDal:GenericRepository<Service>,IServiceDal
{
    
}