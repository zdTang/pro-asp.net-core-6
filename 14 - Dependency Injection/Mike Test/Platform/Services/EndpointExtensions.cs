namespace Platform.Services;

public static class EndpointExtensions
{
    /// <summary>
    ///  Create a extension for IEndpointRouteBuilder
    /// </summary>
    /// <param name="app"></param>
    /// <param name="path"></param>
    public static void MapWeather(this IEndpointRouteBuilder app, string path)
    {
        // Obtain the service from Service Provider [app]
        IResponseFormatter formatter = app.ServiceProvider.GetRequiredService<IResponseFormatter>();
        // Use the service
        app.MapGet(path, context => Platform.WeatherEndpoint.Endpoint(context, formatter));
    }
}