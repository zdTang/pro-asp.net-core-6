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
    
    public ViewResult RsvpForm(){
        return View();
    }


}
