using System.Net;
using System.Net.Http;

namespace RestaurantApiMenulog
{
    public class HttpApplicationResponse
    {
        public HttpResponseMessage CreateResponseMessage<T>(HttpRequestMessage context, HttpStatusCode statusCode, T value = default(T), string errorMessage = null)
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    return OkResponseMessage(context, value);

                case HttpStatusCode.InternalServerError:
                    return InternalErrorResponseMessage(context, errorMessage);

                default:
                    return context.CreateResponse(HttpStatusCode.OK);
            }
        }

        private HttpResponseMessage OkResponseMessage<T>(HttpRequestMessage context, T value)
        {
            return context.CreateResponse(HttpStatusCode.OK, value);
        }

        private HttpResponseMessage InternalErrorResponseMessage(HttpRequestMessage context, string errorMessage)
        {
            return context.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Oops. {errorMessage}");
        }
    }
}