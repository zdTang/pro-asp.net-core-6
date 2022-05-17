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
    
    
    public static void MapEndpointNew<T>(this IEndpointRouteBuilder app, string path, string methodName="Endpoint")
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
        ParameterInfo[] methodParams = methodInfo.GetParameters();
        // Use the service
        app.MapGet(path, context => (Task)(MethodInfo.Invoke(endpointInstance,methodParams.Select(p=>p.ParameterType==typeof(HttpContext)
            ?context
            :app.ServiceProvider.GetService(p.ParameterType)).ToArray())));
    }
    
    
    
    public static void MapEndpointFromBook<T>(this IEndpointRouteBuilder app,
        string path, string methodName = "Endpoint") {

        MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
        if (methodInfo == null || methodInfo.ReturnType != typeof(Task)) {
            throw new System.Exception("Method cannot be used");
        }
        T endpointInstance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);

        ParameterInfo[] methodParams = methodInfo!.GetParameters();
        
        

        app.MapGet(path, context => {
            T endpointInstance = ActivatorUtilities.CreateInstance<T>(context.RequestServices);
            return (Task)methodInfo.Invoke(endpointInstance!,
                methodParams.Select(p => p.ParameterType == typeof(HttpContext)
                    ? context
                    : context.RequestServices.GetService(p.ParameterType)).ToArray())!;
        });
    }
}