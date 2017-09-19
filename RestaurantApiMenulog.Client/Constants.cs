namespace RestaurantApiMenulogClient
{
    public class Constants
    {
#if DEBUG
        public const string RestaurantApiBaseUrl = "http://localhost:1990/api/restaurant";
#else
        public const string RestaurantApiBaseUrl = "https://menulog.com.au/api/restaurant";
#endif
    }
}
