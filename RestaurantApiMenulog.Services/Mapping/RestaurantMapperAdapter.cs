using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantApiMenulog.Domain.Models;
using RestaurantApiMenulog.Models.Application;

namespace RestaurantApiMenulog.Core.Mapping
{
    public class RestaurantMapperAdapter : Interfaces.IRestaurantMapper
    {
        public bool CreateMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RestaurantConfigEntity, RestaurantConfigModel>().ForMember(md => md.DeviceName, m => m.MapFrom(f => f.DeviceName));
                cfg.CreateMap<RestaurantDetailsEntity, RestaurantDetailsModel>().ForMember(md => md.SeoName, m => m.MapFrom(f => f.SeoName));
                cfg.CreateMap<RestaurantFinanceEntity, RestaurantFinanceModel>().ForMember(md => md.CommissionRate, m => m.MapFrom(f => f.CommissionRate));
                cfg.CreateMap<RestaurantEntity, RestaurantModel>().ForMember(md => md.FullName, m => m.MapFrom(f => f.Name));
                cfg.CreateMap<RestaurantDeliverySuburbEntity, RestaurantDeliverySuburbModel>().ForMember(md => md.SuburbName, m => m.MapFrom(f => f.SuburbName));
                cfg.CreateMap<RestaurantScheduleEntity, RestaurantScheduleModel>().ForMember(md => md.Day, m => m.MapFrom(f => f.Day));


                cfg.CreateMap<RestaurantScheduleModel, RestaurantScheduleEntity>().ForMember(md => md.Day, m => m.MapFrom(f => f.Day));
                cfg.CreateMap<RestaurantDeliverySuburbModel, RestaurantDeliverySuburbEntity>().ForMember(md => md.SuburbName, m => m.MapFrom(f => f.SuburbName));
                cfg.CreateMap<RestaurantScheduleModel, RestaurantScheduleEntity>().ForMember(md => md.Day, m => m.MapFrom(f => f.Day));
            });

            return true;
        }

        public RestaurantConfigEntity MapToRestaurantConfigEntity(RestaurantConfigModel restaurantConfig)
        {
            return Mapper.Map<RestaurantConfigModel, RestaurantConfigEntity>(restaurantConfig);
        }

        public RestaurantDetailsEntity MapToRestaurantDetailsEntity(RestaurantDetailsModel restaurantDetails)
        {
            return Mapper.Map<RestaurantDetailsModel, RestaurantDetailsEntity>(restaurantDetails);
        }

        public RestaurantFinanceEntity MapToRestaurantFinanceEntity(RestaurantFinanceModel restaurantFinanceData)
        {
            return Mapper.Map<RestaurantFinanceModel, RestaurantFinanceEntity>(restaurantFinanceData);
        }

        public RestaurantModel MapToRestaurant(RestaurantEntity restaurantData)
        {
            return Mapper.Map<RestaurantEntity, RestaurantModel>(restaurantData);
        }

        public RestaurantDeliverySuburbModel MapToDeliverySuburb(RestaurantDeliverySuburbEntity deliverySuburb)
        {
            return Mapper.Map<RestaurantDeliverySuburbEntity, RestaurantDeliverySuburbModel>(deliverySuburb);
        }

        public RestaurantDeliverySuburbEntity MapToDeliverySuburbEntity(RestaurantDeliverySuburbModel deliverySuburb)
        {
            return Mapper.Map<RestaurantDeliverySuburbModel, RestaurantDeliverySuburbEntity>(deliverySuburb);
        }

        public RestaurantScheduleModel MapToDeliverySuburb(RestaurantScheduleEntity schedule)
        {
            return Mapper.Map<RestaurantScheduleEntity, RestaurantScheduleModel>(schedule);
        }

        public IEnumerable<RestaurantDeliverySuburbModel> MapToDeliverySuburbs(IEnumerable<RestaurantDeliverySuburbEntity> deliverySuburb)
        {
            return deliverySuburb.Select(Mapper.Map<RestaurantDeliverySuburbEntity, RestaurantDeliverySuburbModel>);
        }

        public IEnumerable<RestaurantDeliverySuburbEntity> MapToDeliverySuburbEntities(IEnumerable<RestaurantDeliverySuburbModel> deliverySuburb)
        {
            return deliverySuburb.Select(Mapper.Map<RestaurantDeliverySuburbModel, RestaurantDeliverySuburbEntity>);
        }

        public RestaurantScheduleModel MapToSchedule(RestaurantScheduleEntity schedule)
        {
            return Mapper.Map<RestaurantScheduleEntity, RestaurantScheduleModel>(schedule);
        }

        public RestaurantScheduleEntity MapToScheduleEntity(RestaurantScheduleModel schedule)
        {
            return Mapper.Map<RestaurantScheduleModel, RestaurantScheduleEntity>(schedule);
        }

        public IEnumerable<RestaurantScheduleModel> MapToSchedules(IEnumerable<RestaurantScheduleEntity> schedules)
        {
            return schedules.Select(Mapper.Map<RestaurantScheduleEntity, RestaurantScheduleModel>);
        }

        public IEnumerable<RestaurantScheduleEntity> MapToScheduleEntities(IEnumerable<RestaurantScheduleModel> schedules)
        {
            return schedules.Select(Mapper.Map<RestaurantScheduleModel, RestaurantScheduleEntity>);
        }

        public IEnumerable<RestaurantModel> MapToRestaurants(IEnumerable<RestaurantEntity> restaurantsEnumerableData)
        {
            return restaurantsEnumerableData.Select(Mapper.Map<RestaurantEntity, RestaurantModel>);
        }
    }
}
