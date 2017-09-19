namespace RestaurantMenulogAPi.Domain.Interfaces
{
    public interface IEntityWriter
    {
        void Create<T>(T entity) where T : class;
        void UpdateById<T>(int id, T entity) where T : class;
        void DeleteById(int id);
    }
}
