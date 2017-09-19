using System.Collections.Generic;

namespace RestaurantMenulogAPi.Domain.Interfaces
{
    public interface IEntityReader
    {
        T GetById<T>(int id) where T : class;
        IEnumerable<T> All<T>() where T : class;
        IEnumerable<T> AllById<T>(int id) where T : class;
    }
}
