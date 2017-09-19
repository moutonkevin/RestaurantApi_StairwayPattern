using System;
using System.Collections.Generic;
using RestaurantApiMenulog.Models.Application;

namespace RestaurantApiMenulog.Core.Interfaces
{
    public enum CacheKeys
    {
        AllRestaurants,
        Restaurant,
        RestaurantSuburbs,
        RestaurantSchedules
    }

    public interface ICacheManager
    {
        Dictionary<CacheKeys, CacheModel> CacheKeyConfigs { get; set; }

        bool AddOrReplaceInCache(string key, object value, DateTimeOffset expiration);
        bool AddInCache(string key, object value, DateTimeOffset expiration);
        bool RemoveFromCache(string key);
        T GetFromCache<T>(string key) where T : class;
    }
}
