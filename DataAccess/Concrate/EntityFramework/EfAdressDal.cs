using DataAccess.Abstract;
using DataAccess.Concrate.Repository;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework;

public class EfAdressDal:GenericRepository<Adress>,IAdressDal
{
    
}