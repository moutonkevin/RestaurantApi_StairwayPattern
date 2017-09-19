using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using RestaurantApiMenulog.Core.Interfaces;
using RestaurantApiMenulog.Core.Services.Restaurant;
using RestaurantApiMenulog.Domain.Models;
using RestaurantApiMenulog.Models.Application;
using RestaurantApiMenulog.Services.Interfaces;
using RestaurantApiMenulog.Utils.Interfaces;
using RestaurantMenulogAPi.Domain.Interfaces;

namespace RestaurantApiMenulog.Services.UnitTests
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        private IUnityContainer _container;
        private const string _restaurantMoqName = "Test Moq restaurant";

        [SetUp]
        public void Setup()
        {
            var logMoq = MoqLogger();
            var restaurantRepositoryMoq = MoqRepository();
            var cacheMoq = MoqCache();
            var mapperMoq = MoqMapper();

            _container = new UnityContainer();

            _container.RegisterType<IRestaurantService, RestaurantService>();
            //_container.RegisterType<IRestaurantServiceWriter, RestaurantRepositoryAccess>();
            //_container.RegisterType<IRestaurantServiceReader, RestaurantRepositoryAccess>();
            _container.RegisterInstance<ILogger>(logMoq.Object);
            _container.RegisterInstance<IRestaurantRepository>(restaurantRepositoryMoq.Object);
            _container.RegisterInstance<ICacheManager>(cacheMoq.Object);
            _container.RegisterInstance<IRestaurantMapper>(mapperMoq.Object);
        }

        private IMock<ICacheManager> MoqCache()
        {
            var cacheMoq = new Mock<ICacheManager>();
            cacheMoq.Setup(s => s.GetFromCache<IEnumerable<RestaurantModel>>(It.IsAny<string>())).Returns(() => null);
            cacheMoq.Setup(s => s.AddOrReplaceInCache(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<DateTimeOffset>())).Returns(true);
            cacheMoq.Setup(s => s.CacheKeyConfigs).Returns(new Dictionary<CacheKeys, CacheModel>()
            {
                { CacheKeys.AllRestaurants, new CacheModel  {KeyFormat = "AllRestaurant", DurationSeconds = 300}},
                { CacheKeys.Restaurant, new CacheModel  {KeyFormat = "Restaurant_{0}", DurationSeconds = 300}},
                { CacheKeys.RestaurantSuburbs, new CacheModel  {KeyFormat = "RestaurantSuburb_{0}", DurationSeconds = 300}},
                { CacheKeys.RestaurantSchedules, new CacheModel  {KeyFormat = "RestaurantSchedule_{0}", DurationSeconds = 300}}
            });

            return cacheMoq;
        }

        private IMock<IRestaurantRepository> MoqRepository()
        {
            var restaurantRepositoryMoq = new Mock<IRestaurantRepository>();

            restaurantRepositoryMoq.Setup(s => s.All<RestaurantEntity>()).Returns(
                new List<RestaurantEntity>
                {
                    new RestaurantEntity() { Name = _restaurantMoqName}
                });

            restaurantRepositoryMoq.Setup(s => s.GetById<RestaurantEntity>(It.IsAny<int>())).Returns(
                    new RestaurantEntity() { Name = _restaurantMoqName }
            );

            return restaurantRepositoryMoq;
        }

        private IMock<IRestaurantMapper> MoqMapper()
        {
            var mapperMoq = new Mock<IRestaurantMapper>();

            mapperMoq.Setup(s => s.MapToRestaurants(It.IsAny<IEnumerable<RestaurantEntity>>())).Returns(
                new List<RestaurantModel>
                {
                    new RestaurantModel() { FullName = _restaurantMoqName}
                });
            mapperMoq.Setup(s => s.MapToRestaurant(It.IsAny<RestaurantEntity>())).Returns(
                    new RestaurantModel() { FullName = _restaurantMoqName }
            );

            return mapperMoq;
        }

        private IMock<ILogger> MoqLogger()
        {
            var logMoq = new Mock<ILogger>();
            logMoq.Setup(s => s.LogErrorMessage(It.IsAny<string>()));
            logMoq.Setup(s => s.LogException(It.IsAny<Exception>()));
            logMoq.Setup(s => s.LogMessage(It.IsAny<string>()));

            return logMoq;
        }

        [Test]
        public void RestaurantService_GetRestaurants_Correct()
        {
            var restaurantService = _container.Resolve<IRestaurantService>();

            var restaurants = restaurantService.GetRestaurants();

            Assert.AreEqual("Test Moq restaurant", restaurants.ToList()[0].FullName);
        }

        [Test]
        public void RestaurantService_GetRestaurant_Correct()
        {
            var restaurantService = _container.Resolve<IRestaurantService>();

            var restaurant = restaurantService.GetRestaurant(5);

            Assert.AreEqual("Test Moq restaurant", restaurant.FullName);
        }
    }
}
