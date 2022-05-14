using Platform.Services;

namespace Platform {
    public class WeatherEndpoint {

        /// <summary>
        /// This method is called by the Framework directly, so that Dependencies can be provided
        /// by Application
        /// </summary>
        /// <param name="context"></param>
        /// <param name="formatter"></param>
        public static async Task Endpoint(HttpContext context,IResponseFormatter formatter)
        {
            // Access Service by HttpContext
            //IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            //await context.Response.WriteAsync("Endpoint Class: It is cloudy in Milan");
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}
