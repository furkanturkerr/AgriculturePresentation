using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;

namespace Business.Concrate;

public class AddressManager : IAddressService
{
    private readonly IAdressDal _adressDal;
    public AddressManager(IAdressDal adressDal)
    {
        _adressDal = adressDal;
    }

    public void Insert(Adress t)
    {
        _adressDal.Insert(t);       
    }

    public void Update(Adress t)
    {
        _adressDal.Update(t);      
    }

    public void Delete(Adress t)
    {
        throw new NotImplementedException();
    }

    public Adress GetById(int id)
    {
        return _adressDal.GetById(id);       
    }

    public List<Adress> GetAll()
    {
        return _adressDal.GetAll();       
    }
}