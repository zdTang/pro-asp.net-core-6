var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();  //  Enable MVC Framework

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();   // Add Endpoint for Controller Actions

app.Run();
