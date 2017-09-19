using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using RestaurantApiMenulog.Core.Interfaces;
using RestaurantApiMenulog.Models.Application;
using RestaurantApiMenulog.Utils.Interfaces;

namespace RestaurantApiMenulog.Core.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly ILogger _logger;
        private readonly MemoryCache _cache = MemoryCache.Default;

        public MemoryCacheManager(ILogger logger)
        {
            _logger = logger;
        }

        Dictionary<CacheKeys, CacheModel> ICacheManager.CacheKeyConfigs { get; set; } = new Dictionary<CacheKeys, CacheModel>
        {
            { CacheKeys.AllRestaurants, new CacheModel  {KeyFormat = "AllRestaurant", DurationSeconds = 300}},
            { CacheKeys.Restaurant, new CacheModel  {KeyFormat = "Restaurant_{0}", DurationSeconds = 300}},
            { CacheKeys.RestaurantSuburbs, new CacheModel  {KeyFormat = "RestaurantSuburb_{0}", DurationSeconds = 300}},
            { CacheKeys.RestaurantSchedules, new CacheModel  {KeyFormat = "RestaurantSchedule_{0}", DurationSeconds = 300}},
        };

        public bool AddOrReplaceInCache(string key, object value, DateTimeOffset expiration)
        {
            try
            {
                if (_cache.Contains(key))
                {
                    _cache.Remove(key);
                }
                return _cache.Add(key, value, expiration);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        public bool AddInCache(string key, object value, DateTimeOffset expiration)
        {
            return _cache.Add(key, value, expiration);
        }

        public bool RemoveFromCache(string key)
        {
            try
            {
                if (_cache.Contains(key))
                {
                    return _cache.Remove(key) != null;
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        public T GetFromCache<T>(string key) where T : class
        {
            try
            {
                return _cache.Contains(key) ? _cache.Get(key) as T : default(T);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return default(T);
            }
        }
    }
}
