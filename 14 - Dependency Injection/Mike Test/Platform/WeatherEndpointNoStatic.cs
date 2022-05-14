using Platform.Services;

namespace Platform {
    public class WeatherEndpointNoStatic
    {

        /// <summary>
        /// This one using Instance other than Static method.
        /// Refer to WeatherEndpoint class
        /// </summary>
        private readonly IResponseFormatter _formatter;

        public WeatherEndpointNoStatic(IResponseFormatter responseFormatter)
        {
            _formatter = responseFormatter;
        }
        public async Task Endpoint(HttpContext context)
        {
            
            await _formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}
