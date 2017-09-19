using System.Web.Http;
using Microsoft.Practices.Unity;
using RestaurantApiMenulog.Core.Caching;
using RestaurantApiMenulog.Core.Interfaces;
using RestaurantApiMenulog.Core.Mapping;
using RestaurantApiMenulog.Core.Services.Restaurant;
using RestaurantApiMenulog.Domain.Restaurant;
using RestaurantApiMenulog.Services.Interfaces;
using RestaurantApiMenulog.Utils.Interfaces;
using RestaurantApiMenulog.Utils.Logging;
using RestaurantMenulogAPi.Domain.Interfaces;
using Unity.WebApi;

namespace RestaurantApiMenulog
{
    public static class Ioc
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ILogger, NLogLoggerAdapter>();
            container.RegisterType<IRestaurantService, RestaurantService>();
            container.RegisterType<IRestaurantRepository, RestaurantRepository>();
            container.RegisterType<IDeliverySuburbsRepository, DeliverySuburbsRepository>();
            container.RegisterType<ICacheManager, MemoryCacheManager>();
            container.RegisterType<IRestaurantMapper, RestaurantMapperAdapter>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}