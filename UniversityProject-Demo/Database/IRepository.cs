namespace UniversityProject_Demo.Database
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
       bool Get(int id);
        bool Create(T entity);
        bool Delete(int id);
        bool Update(T entity);
        T? GetById(int id);

    }
}
