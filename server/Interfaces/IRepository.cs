
namespace help_reviews.Interfaces;

// NOTE an interface is a contract that a class must adhere to, it must support the methods from the interface, but the class has the implementation of the method
public interface IRepository<T>
{
  public T Create(T data);
  public T Update(T data);
  public void Delete(int id);
  public List<T> GetAll();
  public T GetById(int id);
}