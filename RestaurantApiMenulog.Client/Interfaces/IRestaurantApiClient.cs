using System.Threading.Tasks;
using RestaurantApiMenulog.Models.Application;

namespace RestaurantApiMenulogClient.Interfaces
{
    public interface IRestaurantApiClient
    {
        Task<RestaurantModel> GetRestaurantAsync(int restaurantId);
    }
}
