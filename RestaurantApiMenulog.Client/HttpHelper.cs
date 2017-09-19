using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestaurantApiMenulogClient
{
    public class HttpHelper
    {
        public async Task<TOutput> Get<TOutput>(string url)
        {
            var webRequest = WebRequest.Create(url);

            webRequest.Method = WebRequestMethods.Http.Get;
            webRequest.Headers.Clear();
            webRequest.Headers.Add("Accept", "application/json");

            using (var response = await webRequest.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<TOutput>(content);
            }
        }
    }
}
