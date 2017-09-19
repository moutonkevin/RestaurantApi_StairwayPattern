using System;
using System.Collections.Generic;
using RestaurantApiMenulog.Domain.Models;
using RestaurantMenulogAPi.Domain.Interfaces;

namespace RestaurantApiMenulog.Domain.Restaurant
{
    public class DeliverySuburbsRepository : IDeliverySuburbsRepository
    {
        public T GetById<T>(int id) where T : class
        {
            return new RestaurantDeliverySuburbEntity
            {
                SuburbName = "Potts Point"
            } as T;
        }

        public IEnumerable<T> All<T>() where T : class
        {
            return new List<RestaurantDeliverySuburbEntity>
            {
                new RestaurantDeliverySuburbEntity
                {
                    SuburbName = "Potts Point"
                },
                new RestaurantDeliverySuburbEntity
                {
                    SuburbName = "Kings Cross"
                }
            }  as IEnumerable<T>;
        }

        public IEnumerable<T> AllById<T>(int id) where T : class
        {
            return new List<RestaurantDeliverySuburbEntity>
            {
                new RestaurantDeliverySuburbEntity
                {
                    SuburbName = "Surry Hills"
                },
                new RestaurantDeliverySuburbEntity
                {
                    SuburbName = "Kings Cross"
                }
            } as IEnumerable<T>;
        }

        public void Create<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Create<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public void UpdateById<T>(int id, T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById<T>(int id) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById<T>(int id, IEnumerable<T> entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
