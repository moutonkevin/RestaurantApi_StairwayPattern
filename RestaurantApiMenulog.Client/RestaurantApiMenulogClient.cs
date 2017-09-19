using System.Threading.Tasks;
using RestaurantApiMenulog.Models.Application;
using RestaurantApiMenulogClient.Interfaces;

namespace RestaurantApiMenulogClient
{
    public class RestaurantApiMenulogClient : IRestaurantApiClient
    {
        public async Task<RestaurantModel> GetRestaurantAsync(int restaurantId)
        {
            var url = $"{Constants.RestaurantApiBaseUrl}/{restaurantId}";

            var httpHelper = new HttpHelper();

            var restaurant = await httpHelper.Get<RestaurantModel>(url);

            return restaurant;
        }
    }
}
