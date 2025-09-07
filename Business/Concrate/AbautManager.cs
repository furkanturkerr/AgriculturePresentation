using Business.Abstract;
using DataAccess.Abstract;
using Entity;

namespace Business.Concrate;

public class AbautManager:IAbautService
{
    private readonly IAbautDal _abautDal;
    public AbautManager(IAbautDal abautDal)
    {
        _abautDal = abautDal;
    }
    public void Insert(Abaut t)
    {
        _abautDal.Insert(t);      
    }

    public void Update(Abaut t)
    {
        _abautDal.Update(t);      
    }

    public void Delete(Abaut t)
    {
        _abautDal.Delete(t);      
    }

    public Abaut GetById(int id)
    {
        return _abautDal.GetById(id);      
    }

    public List<Abaut> GetAll()
    {
        return _abautDal.GetAll();     
    }
}