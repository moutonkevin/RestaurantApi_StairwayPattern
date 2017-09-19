using System;
using System.Collections.Generic;
using RestaurantApiMenulog.Core.Interfaces;
using RestaurantApiMenulog.Domain.Models;
using RestaurantApiMenulog.Models.Application;
using RestaurantApiMenulog.Services.Interfaces;
using RestaurantMenulogAPi.Domain.Interfaces;

namespace RestaurantApiMenulog.Core.Services.Restaurant
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDeliverySuburbsRepository _restaurantDeliverySuburbsRepository;
        private readonly ICacheManager _cache;
        private readonly IRestaurantMapper _mapper;

        public RestaurantService(
            IRestaurantRepository restaurantDataSource,
            IDeliverySuburbsRepository restaurantDeliverySuburbsRepository,
            ICacheManager cache,
            IRestaurantMapper mapper)
        {
            _restaurantRepository = restaurantDataSource;
            _cache = cache;
            _mapper = mapper;
            _restaurantDeliverySuburbsRepository = restaurantDeliverySuburbsRepository;

            _mapper.CreateMapper();
        }

        public bool AddDeliverySuburbs(int restaurantId, IEnumerable<RestaurantDeliverySuburbModel> value)
        {
            _restaurantDeliverySuburbsRepository.Create(value);

            return true;
        }

        public bool AddDeliverySuburb(RestaurantDeliverySuburbModel value)
        {
            _restaurantDeliverySuburbsRepository.Create(value);

            return true;
        }

        public bool AddSchedules(int restaurantId, IEnumerable<RestaurantScheduleModel> value)
        {
            //var scheduleEntities = _mapper.MapToScheduleEntities(value);
            //return _restaurantRepository.AddSchedules(restaurantId, scheduleEntities);
            return true;
        }

        public bool AddSchedule(int restaurantId, RestaurantScheduleModel value)
        {
            //var scheduleEntity = _mapper.MapToScheduleEntity(value);
            //return _restaurantRepository.AddSchedule(restaurantId, scheduleEntity);
            return true;
        }

        public bool UpdateDeliverySuburbs(int restaurantId, IEnumerable<RestaurantDeliverySuburbModel> value)
        {
            //var deliverySuburbsData = _mapper.MapToDeliverySuburbEntities(value);
            //return _restaurantRepository.UpdateDeliverySuburbs(restaurantId, deliverySuburbsData);
            return true;
        }

        public bool UpdateConfig(int restaurantId, RestaurantConfigModel value)
        {
            //var configData = _mapper.MapToRestaurantConfigEntity(value);
            //return _restaurantRepository.UpdateConfig(restaurantId, configData);
            return true;
        }

        public bool UpdateDetails(int restaurantId, RestaurantDetailsModel value)
        {
            //var detailsData = _mapper.MapToRestaurantDetailsEntity(value);
            //return _restaurantRepository.UpdateDetails(restaurantId, detailsData);
            return true;
        }

        public bool UpdateFinance(int restaurantId, RestaurantFinanceModel value)
        {
            //var financeData = _mapper.MapToRestaurantFinanceEntity(value);
            //return _restaurantRepository.UpdateFinance(restaurantId, financeData);
            return true;
        }

        public bool UpdateSchedule(int restaurantId, RestaurantScheduleModel value)
        {
            //var scheduleData = _mapper.MapToScheduleEntity(value);
            //return _restaurantRepository.UpdateSchedule(restaurantId, scheduleData);
            return true;
        }

        public IEnumerable<RestaurantDeliverySuburbModel> GetDeliverySuburbs(int restaurantId)
        {

            var cachedSuburbs = GetFromCache<IEnumerable<RestaurantDeliverySuburbModel>>(CacheKeys.RestaurantSuburbs, restaurantId);
            if (cachedSuburbs != null)
            {
                return cachedSuburbs;
            }

            var suburbs = _restaurantDeliverySuburbsRepository.AllById<RestaurantDeliverySuburbEntity>(restaurantId);
            var suburbsToReturn = _mapper.MapToDeliverySuburbs(suburbs);

            AddToCache(CacheKeys.RestaurantSuburbs, suburbsToReturn, restaurantId);

            return suburbsToReturn;
        }

        public IEnumerable<RestaurantScheduleModel> GetSchedules(int restaurantId)
        {
            //var cachedSchedules = GetFromCache<IEnumerable<RestaurantScheduleModel>>(CacheKeys.RestaurantSchedules, restaurantId);
            //if (cachedSchedules != null)
            //{
            //    return cachedSchedules;
            //}

            //var schedules = _restaurantRepository.GetSchedules(restaurantId);
            //var schedulesToReturn = _mapper.MapToSchedules(schedules);

            //AddToCache(CacheKeys.RestaurantSchedules, schedulesToReturn, restaurantId);

            //return schedulesToReturn;

            return null;
        }

        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            var cachedRestaurants = GetFromCache<IEnumerable<RestaurantModel>>(CacheKeys.AllRestaurants);
            if (cachedRestaurants != null)
            {
                return cachedRestaurants;
            }

            var restaurants = _restaurantRepository.All<RestaurantEntity>();
            var restaurantsToReturn = _mapper.MapToRestaurants(restaurants);

            AddToCache(CacheKeys.AllRestaurants, restaurantsToReturn);

            return restaurantsToReturn;
        }

        public RestaurantModel GetRestaurant(int restaurantId)
        {
            var cachedRestaurant = GetFromCache<RestaurantModel>(CacheKeys.Restaurant, restaurantId);
            if (cachedRestaurant != null)
            {
                return cachedRestaurant;
            }

            var restaurant = _restaurantRepository.GetById<RestaurantEntity>(restaurantId);
            var restaurantToReturn = _mapper.MapToRestaurant(restaurant);

            AddToCache(CacheKeys.Restaurant, restaurantToReturn, restaurantId);

            return restaurantToReturn;
        }

        private T GetFromCache<T>(CacheKeys cacheKey, params object[] formatParams) where T : class
        {
            var cacheConfig = _cache.CacheKeyConfigs[cacheKey];
            var restaurantCacheKey = string.Format(cacheConfig.KeyFormat, formatParams);

            return _cache.GetFromCache<T>(restaurantCacheKey);
        }

        private void AddToCache(CacheKeys cacheKey, object value, params object[] formatParams)
        {
            var cacheConfig = _cache.CacheKeyConfigs[cacheKey];
            var key = string.Format(cacheConfig.KeyFormat, formatParams);

            var cacheDuration = DateTimeOffset.UtcNow.AddSeconds(cacheConfig.DurationSeconds);

            _cache.AddOrReplaceInCache(key, value, cacheDuration);
        }

        //public T GetById<T>(int id) where T : class
        //{
        //    var cachedRestaurant = GetFromCache<T>(CacheKeys.Restaurant, id);
        //    if (cachedRestaurant != null)
        //    {
        //        return cachedRestaurant;
        //    }

        //    var restaurant = _restaurantRepository.GetRestaurant(id);
        //    var restaurantToReturn = _mapper.MapToRestaurant(restaurant);

        //    AddToCache(CacheKeys.Restaurant, restaurantToReturn, id);

        //    return restaurantToReturn as T;
        //}

        //public IEnumerable<T> All<T>() where T : class
        //{
        //    var cachedRestaurants = GetFromCache<IEnumerable<T>>(CacheKeys.AllRestaurants);
        //    if (cachedRestaurants != null)
        //    {
        //        return cachedRestaurants;
        //    }

        //    var restaurants = _restaurantRepository.GetRestaurants();
        //    var restaurantsToReturn = _mapper.MapToRestaurants(restaurants);

        //    AddToCache(CacheKeys.AllRestaurants, restaurantsToReturn);

        //    return restaurantsToReturn as IEnumerable<T>;
        //}

        //public void Create<T>(T entity) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateById<T>(int id, T entity) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteById<T>(int id) where T : class
        //{
        //    throw new NotImplementedException();
        //}
    }
}
