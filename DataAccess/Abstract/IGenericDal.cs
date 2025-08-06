namespace DataAccess.Abstract;

public interface IGenericDal<T> where T : class
{
    void Insert(T t);
    void Update(T t);
    void Delete(T t);
    T GetById(int id);
    List<T> GetAll();
}