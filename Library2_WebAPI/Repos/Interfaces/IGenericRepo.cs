namespace Library2_WebAPI.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public ICollection<T> GetAll();
        public T GetById(int id);   
        public void CreateEntity(T entity);
        public void UpdateEntity(T entity);
        public void DeleteEntity(T entity);

    }
}
