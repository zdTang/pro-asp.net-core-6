var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();         // init MVC framework

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();                    // using default MVC routing method

app.Run();
