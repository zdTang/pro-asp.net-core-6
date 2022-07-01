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


        public IViewComponentResult Invoke(){
            return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
        }
    }
}