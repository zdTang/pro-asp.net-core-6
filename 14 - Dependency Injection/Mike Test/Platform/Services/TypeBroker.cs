namespace Platform.Services;

public static class TypeBroker
{
    // The problem of this approach is the Interface will limit us to access all functions provided by the concrete Instance 
    
    //public static IResponseFormatter Formatter { get; } = new TextResponseFormatter();
    public static IResponseFormatter Formatter { get; } = new HtmlResponseFormatter(); // Use different implementation
}