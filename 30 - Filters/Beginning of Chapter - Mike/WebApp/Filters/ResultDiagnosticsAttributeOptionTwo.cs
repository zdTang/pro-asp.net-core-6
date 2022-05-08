using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApp.Filters;
/// <summary>
/// This is a very good demo how to response Statistic or Debug Information by using Result Filter
/// Result Filter will run after the Action Result has been created.
/// Once Result Filter take the Action Result, it can do lots of analysis on it and create a alternative Action Result !!
/// Based on the new Action Result, we can specify to response Different View, Page and Data Model
/// </summary>
public class ResultDiagnosticsOptionTwoAttribute:ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        // Here we can replace the whole response in the Result Filter according to extra key in the Request URL
        if (context.HttpContext.Request.Query.ContainsKey("diag")) {
            Dictionary<string, string?> diagData =
                new Dictionary<string, string?> {
                    {"Result type", context.Result.GetType().Name }
                };
            if (context.Result is ViewResult vr) {
                diagData["View Name"] = vr.ViewName;
                diagData["Model Type"] = vr.ViewData?.Model?.GetType().Name;
                diagData["Model Data"] = vr.ViewData?.Model?.ToString();
            } else if (context.Result is PageResult pr) {
                diagData["Model Type"] = pr.Model.GetType().Name;
                diagData["Model Data"] = pr.ViewData?.Model?.ToString();
            }
            
            // Here we are creating a new ViewResult
            context.Result = new ViewResult() {
                ViewName = "/Views/Shared/Message.cshtml",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary()) {
                    Model = diagData
                }
            };
        }
        await next();     // This will execute the Action Result
        
        // After Action Result has been executed !
        var nonsense = string.Empty;
    }
}