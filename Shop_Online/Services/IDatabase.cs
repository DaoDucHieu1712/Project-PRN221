namespace Shop_Online.Services
{
    public interface IDatabase
    {
        T GetById<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
