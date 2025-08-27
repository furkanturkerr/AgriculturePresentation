using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;

namespace Business.Concrate;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;
    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }   
    private IContactService _contactServiceImplementation;
    public void Insert(Contact t)
    {
        _contactServiceImplementation.Insert(t);
    }

    public void Update(Contact t)
    {
        _contactServiceImplementation.Update(t);
    }

    public void Delete(Contact t)
    {
        _contactDal.Delete(t);
    }

    public Contact GetById(int id)
    {
        return _contactDal.GetById(id);       
    }

    public List<Contact> GetAll()
    {
        return _contactDal.GetAll();       
    }
}