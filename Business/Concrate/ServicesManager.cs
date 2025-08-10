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
        _servicedal.Update(t);      
    }

    public void Delete(Service t)
    {
        _servicedal.Delete(t);  
    }

    public Service GetById(int id)
    {
       return _servicedal.GetById(id);       
    }

    public List<Service> GetAll()
    {
        return _servicedal.GetAll();       
    }
}