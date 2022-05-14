using Platform.Services;

namespace Platform {
    public class WeatherMiddleware {
        private RequestDelegate next;
        private IResponseFormatter _formatter;
        public WeatherMiddleware(RequestDelegate nextDelegate,IResponseFormatter formatter) {
            next = nextDelegate;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Path == "/middleware/class")
            {
                await _formatter.Format(context, "Middleware Class: It is raining in London");
            }
            else {
                await next(context);
                // If Respond Header has been sent, then it will cause Error here.
                //await _formatter.Format(context, "Middleware Class: It is raining in London again!");
            }
        }
    }
}
