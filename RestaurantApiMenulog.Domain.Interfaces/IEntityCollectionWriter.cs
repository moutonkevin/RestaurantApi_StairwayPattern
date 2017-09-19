using System.Collections.Generic;

namespace RestaurantMenulogAPi.Domain.Interfaces
{
    public interface IEntityCollectionWriter : IEntityWriter
    {
        void Create<T>(IEnumerable<T> entities) where T : class;
        void UpdateById<T>(int id, IEnumerable<T> entity) where T : class;
        void DeleteByIds(IEnumerable<int> ids);
    }
}
