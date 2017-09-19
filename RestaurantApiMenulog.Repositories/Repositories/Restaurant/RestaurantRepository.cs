using System;
using System.Collections.Generic;
using RestaurantApiMenulog.Core.DataAccess.Models;
using RestaurantApiMenulog.Core.Interfaces;
using RestaurantApiMenulog.Core.Interfaces.Restaurants;

namespace RestaurantApiMenulog.Core.Repositories.Restaurant
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ILogger _logger;

        public RestaurantRepository(ILogger logger)
        {
            _logger = logger;
        }

        public bool UpdateConfig(int restaurantId, RestaurantConfigDataEntity value)
        {
            return true;
        }

        public bool UpdateDeliverySuburbs(int restaurantId, IEnumerable<RestaurantDeliverySuburbDataEntity> value)
        {
            return true;
        }

        public bool UpdateDetails(int restaurantId, RestaurantDetailsDataEntity value)
        {
            return true;
        }

        public bool UpdateFinance(int restaurantId, RestaurantFinanceDataEntity value)
        {
            return true;
        }

        public bool UpdateSchedule(int restaurantId, RestaurantScheduleDataEntity value)
        {
            return true;
        }

        public IEnumerable<RestaurantDeliverySuburbDataEntity> GetDeliverySuburbs(int restaurantId)
        {
            return new List<RestaurantDeliverySuburbDataEntity>
            {
                new RestaurantDeliverySuburbDataEntity
                {
                    SuburbName = "Surry Hills"
                }
            };
        }

        public IEnumerable<RestaurantScheduleDataEntity> GetSchedules(int restaurantId)
        {
            return new List<RestaurantScheduleDataEntity>
            {
                new RestaurantScheduleDataEntity
                {
                    Day = DayOfWeek.Friday
                }
            };
        }

        public IEnumerable<RestaurantDataEntity> GetRestaurants()
        {
            return new List<RestaurantDataEntity>
            {
                new RestaurantDataEntity
                {
                    Name = "Orange is the new Black"
                }
            };
        }

        public RestaurantDataEntity GetRestaurant(int restaurantId)
        {
            return new RestaurantDataEntity
            {
                Name = "Test restaurant"
            };
        }
    }
}
