using System.Reflection;

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
    
    
    /// <summary>
    ///  Generic Type Extension
    /// </summary>
    /// <param name="app"></param>
    /// <param name="path"></param>
    /// <param name="methodName"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="SystemException"></exception>
    
    
    public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName="Endpoint")
    {
        // Get information of the methodName by Reflection
        // If method is Static, here will occur Error
        MethodInfo? methodInfo = typeof(T).GetMethod(methodName);

        if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
        {
            throw new SystemException("Method cannot be used");
        }
        
        // Create an Instance of T by ActivatorUtilities
        T endpointInstance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);
        
        // Use the service
        app.MapGet(path, (RequestDelegate)methodInfo.CreateDelegate(typeof(RequestDelegate),endpointInstance));
    }
}