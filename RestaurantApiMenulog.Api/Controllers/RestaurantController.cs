using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantApiMenulog.Services.Interfaces;

namespace RestaurantApiMenulog.Controllers
{
    [RoutePrefix("api/restaurant")]
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService business)
        {
            _restaurantService = business;
        }

        [Route("")]
        public HttpResponseMessage GetRestaurants()
        {
            try
            {
                var restaurants = _restaurantService.GetRestaurants();

                return new HttpApplicationResponse().CreateResponseMessage(Request, HttpStatusCode.OK, restaurants);
            }
            catch (Exception exp)
            {
                return new HttpApplicationResponse().CreateResponseMessage(Request, HttpStatusCode.InternalServerError, exp.Message);
            }
        }

        [Route("{id:int}")]
        public HttpResponseMessage GetRestaurant(int id)
        {
            try
            {
                var restaurant = _restaurantService.GetRestaurant(id);

                return new HttpApplicationResponse().CreateResponseMessage(Request, HttpStatusCode.OK, restaurant);
            }
            catch (Exception exp)
            {
                return new HttpApplicationResponse().CreateResponseMessage(Request, HttpStatusCode.InternalServerError, exp.Message);
            }
        }

        [Route("{id:int}/deliverysuburbs")]
        public HttpResponseMessage GetRestaurantDeliverySuburbs(int id)
        {
            try
            {
                var restaurant = _restaurantService.GetDeliverySuburbs(id);

                return new HttpApplicationResponse().CreateResponseMessage(Request, HttpStatusCode.OK, restaurant);
            }
            catch (Exception exp)
            {
                return new HttpApplicationResponse().CreateResponseMessage(Request, HttpStatusCode.InternalServerError, exp.Message);
            }
        }
    }
}
