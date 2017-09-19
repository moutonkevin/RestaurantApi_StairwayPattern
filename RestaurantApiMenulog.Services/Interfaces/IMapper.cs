using System.Collections.Generic;
using RestaurantApiMenulog.Domain.Models;
using RestaurantApiMenulog.Models.Application;

namespace RestaurantApiMenulog.Core.Interfaces
{
    public interface IRestaurantMapper
    {
        bool CreateMapper();

        RestaurantConfigEntity MapToRestaurantConfigEntity(RestaurantConfigModel restaurantConfig);
        RestaurantDetailsEntity MapToRestaurantDetailsEntity(RestaurantDetailsModel restaurantDetails);
        RestaurantFinanceEntity MapToRestaurantFinanceEntity(RestaurantFinanceModel restaurantFinanceData);

        RestaurantModel MapToRestaurant(RestaurantEntity restaurantData);
        IEnumerable<RestaurantModel> MapToRestaurants(IEnumerable<RestaurantEntity> restaurantsEnumerableData);

        RestaurantDeliverySuburbModel MapToDeliverySuburb(RestaurantDeliverySuburbEntity deliverySuburb);
        RestaurantDeliverySuburbEntity MapToDeliverySuburbEntity(RestaurantDeliverySuburbModel deliverySuburb);
        IEnumerable<RestaurantDeliverySuburbModel> MapToDeliverySuburbs(IEnumerable<RestaurantDeliverySuburbEntity> deliverySuburb);
        IEnumerable<RestaurantDeliverySuburbEntity> MapToDeliverySuburbEntities(IEnumerable<RestaurantDeliverySuburbModel> deliverySuburb);

        RestaurantScheduleModel MapToSchedule(RestaurantScheduleEntity schedule);
        RestaurantScheduleEntity MapToScheduleEntity(RestaurantScheduleModel schedule);
        IEnumerable<RestaurantScheduleModel> MapToSchedules(IEnumerable<RestaurantScheduleEntity> schedules);
        IEnumerable<RestaurantScheduleEntity> MapToScheduleEntities(IEnumerable<RestaurantScheduleModel> schedules);
    }
}
