using Platform.Services;

namespace Platform {
    public class WeatherMiddlewareMoveDependencyToInvoke {
        private RequestDelegate next;
        //private IResponseFormatter _formatter;
        public WeatherMiddlewareMoveDependencyToInvoke(RequestDelegate nextDelegate/*,IResponseFormatter formatter*/) {
            next = nextDelegate;
            //_formatter = formatter;
        }

        public async Task Invoke(HttpContext context,IResponseFormatter formatter) {
            if (context.Request.Path == "/middleware/class")
            {
                await formatter.Format(context, "Middleware Class: It is raining in London--Move dependency to Invoke");
            }
            else {
                await next(context);
                // If Respond Header has been sent, then it will cause Error here.
                //await _formatter.Format(context, "Middleware Class: It is raining in London again!");
            }
        }
    }
}
