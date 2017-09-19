using System.Collections.Generic;
using RestaurantApiMenulog.Models.Application;

namespace RestaurantApiMenulog.Services.Interfaces
{
    public interface IRestaurantServiceReader
    {
        IEnumerable<RestaurantDeliverySuburbModel> GetDeliverySuburbs(int restaurantId);
        //IEnumerable<RestaurantScheduleModel> GetSchedules(int restaurantId);
        IEnumerable<RestaurantModel> GetRestaurants();
        RestaurantModel GetRestaurant(int restaurantId);
    }
}
