using System;
using System.Collections.Generic;
using RestaurantMenulogAPi.Domain.Interfaces;
using RestaurantApiMenulog.Domain.Models;
using RestaurantApiMenulog.Utils.Interfaces;

namespace RestaurantApiMenulog.Domain.Restaurant
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ILogger _logger;

        public RestaurantRepository(ILogger logger)
        {
            _logger = logger;
        }

        public T GetById<T>(int id) where T : class
        {
            return new RestaurantEntity
            {
                Name = "Test restaurant"
            } as T;
        }

        public IEnumerable<T> All<T>() where T : class
        {
            return new List<RestaurantEntity>
            {
                new RestaurantEntity
                {
                    Name = "Orange is the new Black"
                }
            } as IEnumerable<T>;
        }

        public IEnumerable<T> AllById<T>(int id) where T : class
        {
            return new List<RestaurantEntity>
            {
                new RestaurantEntity
                {
                    Name = "Orange is the new Black"
                },
                new RestaurantEntity
                {
                    Name = "Orange is the new Black 2"
                }
            } as IEnumerable<T>;
        }

        public void Create<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void UpdateById<T>(int id, T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
