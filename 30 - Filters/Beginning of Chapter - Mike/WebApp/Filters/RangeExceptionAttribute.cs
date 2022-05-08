using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApp.Filters;

public class RangeExceptionAttribute:ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context) {
        // Here Base on different Exception type, we can specify different response information
        if (context.Exception is ArgumentOutOfRangeException) {
            context.Result = new ViewResult() {
                
                // This is a good demo to display ERROR INFORMATION
                ViewName = "/Views/Shared/Message.cshtml",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary()) {
                    Model = @"The data received by the
                                application cannot be processed"
                }
            };
        }
    }
}