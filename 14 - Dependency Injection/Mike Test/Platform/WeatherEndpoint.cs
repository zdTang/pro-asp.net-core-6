using Platform.Services;

namespace Platform {
    public class WeatherEndpoint {

        public static async Task Endpoint(HttpContext context)
        {
            // Access Service by HttpContext
            IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            //await context.Response.WriteAsync("Endpoint Class: It is cloudy in Milan");
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}
