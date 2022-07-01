using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;

namespace WebApp.Components
{
    public class CitySummary : ViewComponent
    {
        private CitiesData data;
        public CitySummary(CitiesData cdata)
        {
            data = cdata;
        }
        // Here we return string, actually we can 
        // return other types
        // public string Invoke()
        // {
        //     return $"{data.Cities.Count()} cities, " + $"{data.Cities.Sum(c => c.Population)} people";
        // }


        // Here we return a View with Model
        // public IViewComponentResult Invoke(){
        //     return View(new CityViewModel{
        //         Cities=data.Cities.Count(),
        //         Population=data.Cities.Sum(c=>c.Population)
        //     });
        // }

        // Content always return a encoded string
        // public IViewComponentResult Invoke(){
        //     return Content("This is a <h3><i>string</i></h3>");
        // }

        // Return unEncoded HTML fragment
        // public IViewComponentResult Invoke(){
        //     return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
        // }


        // Using string directly will return encoded HTML Fragment 
        //  public string Invoke(){
        //     return "<h3><i>string-Mike</i></h3>";
        // }

         
        // Using Context data
        //  public string Invoke(){
        //     if(RouteData.Values["controller"]!=null){
        //         return " Controller Request";
        //     }
        //     else{
        //         return "Razor Page Request";
        //     }
            
        // }


        // ViewComponent to receive a parameter

           public IViewComponentResult Invoke(string themeName){
            
            ViewBag.Theme = themeName;
            return View(new CityViewModel{
                Cities=data.Cities.Count(),
                Population=data.Cities.Sum(c=>c.Population)
            });
            
        }
    }
}