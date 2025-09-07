using DataAccess.Abstract;
using DataAccess.Concrate.Repository;
using Entity;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework;

public class EfAbautDal: GenericRepository<Abaut>,IAbautDal
{
}