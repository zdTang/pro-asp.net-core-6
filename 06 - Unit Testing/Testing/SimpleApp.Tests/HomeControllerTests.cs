using Microsoft.AspNetCore.Mvc;
using SimpleApp.Controllers;
using SimpleApp.Models;
using System.Collections.Generic;
using Xunit;

namespace SimpleApp.Tests
{
    public  class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] data) => Products = data;
            public IEnumerable<Product> Products {get;set; }
        }


        [Fact]
        //public void IndexActionModelIsComplete()
        //{
        //    //Arrange
        //    var controller = new HomeController();
        //    Product[] products = new Product[]
        //    {
        //        new Product{Name="Kayak",Price=275M},
        //        new Product{Name="Lifejacket",Price=48.95M}
        //    };
        //    //Act
        //    var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
        //    //Assert
        //    Assert.Equal(products, model, Comparer.Get<Product>((p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price));
        //}
        public void IndexActionModelIsComplete()
        {
            //Arrange
            
            Product[] products = new Product[]
            {
                new Product{Name="p1",Price=275M},
                new Product{Name="p2",Price=48.95M},
                new Product{Name="p3",Price=48.95M}
            };
            IDataSource data = new FakeDataSource(products);
            var controller = new HomeController();
            controller.dataSource = data;             // Notice this is Controller's property
            //Act  
            var model = controller.Index()?.ViewData.Model as IEnumerable<Product>;
            //Assert
            Assert.Equal(data.Products, model, Comparer.Get<Product>((p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price));
        }
    }
}
