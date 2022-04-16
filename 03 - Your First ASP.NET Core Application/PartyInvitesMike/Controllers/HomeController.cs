using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartyInvitesMike.Models;

namespace PartyInvitesMike.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public ViewResult RsvpForm()
    {
        return View();
    }

    [HttpPost]
    public ViewResult RsvpForm(GuestResponse gr)
    {
        if (ModelState.IsValid)
        {
            Repository.AddResponse(gr);
            return View("Thanks",gr);
        }

        return View();
    }

    public ViewResult ListResponses()
    {
        return View(Repository.Responses.Where(r => r.WillAttend == true));
    }


}
