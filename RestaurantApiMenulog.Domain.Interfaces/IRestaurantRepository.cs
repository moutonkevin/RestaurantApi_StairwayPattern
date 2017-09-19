using RestaurantApiMenulog.Domain.Models;
using System.Collections.Generic;

namespace RestaurantMenulogAPi.Domain.Interfaces
{
    public interface IRestaurantRepository : IEntityReader, IEntityWriter
    {
        #region write

        //bool AddDeliverySuburbs(int restaurantId, IEnumerable<RestaurantDeliverySuburbEntity> value);
        //bool AddDeliverySuburb(int restaurantId, RestaurantDeliverySuburbEntity value);
        //bool AddSchedules(int restaurantId, IEnumerable<RestaurantScheduleEntity> value);
        //bool AddSchedule(int restaurantId, RestaurantScheduleEntity value);
        //bool UpdateConfig(int restaurantId, RestaurantConfigEntity value);
        //bool UpdateDeliverySuburbs(int restaurantId, IEnumerable<RestaurantDeliverySuburbEntity> value);
        //bool UpdateDetails(int restaurantId, RestaurantDetailsEntity value);
        //bool UpdateFinance(int restaurantId, RestaurantFinanceEntity value);
        //bool UpdateSchedule(int restaurantId, RestaurantScheduleEntity value);

        //#endregion

        //#region read

        //IEnumerable<RestaurantDeliverySuburbEntity> GetDeliverySuburbs(int restaurantId);
        //IEnumerable<RestaurantScheduleEntity> GetSchedules(int restaurantId);
        //IEnumerable<RestaurantEntity> GetRestaurants();
        //RestaurantEntity GetRestaurant(int restaurantId);

        #endregion
    }
}
