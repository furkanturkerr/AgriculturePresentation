using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;

namespace Business.Concrate;

public class ServicesManager : IServiceService
{
    private readonly IServiceDal _servicedal;

    public ServicesManager(IServiceDal servicedal)
    {
        _servicedal = servicedal;
    }

    public void Insert(Service t)
    {
        _servicedal.Insert(t);       
    }

    public void Update(Service t)
    {
        throw new NotImplementedException();
    }

    public void Delete(Service t)
    {
        throw new NotImplementedException();
    }

    public Service GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Service> GetAll()
    {
        return _servicedal.GetAll();       
    }
}