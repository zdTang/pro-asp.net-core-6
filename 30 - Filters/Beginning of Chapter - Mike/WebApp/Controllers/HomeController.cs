using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Filters;

namespace WebApp;

/// <summary>
/// Different level of filter!! Controller level
/// </summary>

//[SimpleCacheAsync]
[ResultDiagnostics]
[ServiceFilter(typeof(GuidResponseAttribute))]
[ServiceFilter(typeof(GuidResponseAttribute))]

//[GuidResponseFilterFactory]
//[GuidResponseFilterFactory]
public class HomeController : Controller
{    
  
    //[HttpsOnly]
    //[SimpleCache]
    
    public IActionResult Index()
    {
       return View("Message","This is the Index action on the Home Controller");
    }
    

    //[RequireHttps]
    public IActionResult Secure()
    {
        return View("Message","This is the Secure action on the Home Controller");
    }

    //[ChangeArgAnotherOption]
    public IActionResult Messages(string message1, string message2 = "None")
    {
        return View("Message", $"{message1},{message2}");
    }
    
    public IActionResult MessagesTwo(string message1, string message2 = "None")
    {
        return Ok($"{message1},{message2}");
    }

    /// <summary>
    ///  This Controller Filter Method will be applied to any action within this Controller, and controllers derived from this Controller
    ///  So that either Messages or MessageTwo will be filtered by this action
    /// </summary>
    /// <param name="context"></param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("message1"))
        {
            context.ActionArguments["message1"] = "new message";
        }
    }
    /// <summary>
    ///  This asynchronous option works too. But only one option( Check documentation) will be applied.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //After Model-Binding, Before Action Execution
        if (context.ActionArguments.ContainsKey("message1"))
        {
            context.ActionArguments["message1"] = "new message";
        }
        
        await next();
        
        //After Action Execution, Before Action-Result Execution
    }

    
    /// <summary>
    /// Exception Filter need to be append to the Controller, Page or Action
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [RangeException]
    public ViewResult GenerateException(int? id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }else if (id > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }
        else
        {
            return View("Message", $"The value is {id}");
        }
    }
}