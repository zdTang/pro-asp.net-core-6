using Microsoft.EntityFrameworkCore;
using WebApp.Filters;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Use Dependency Injection to Manage Filter Lifecycles
builder.Services.AddScoped<GuidResponseAttribute>();

var app = builder.Build();


// configure Pipeline here
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();

// Be aware this, how to get DbContext in the PipeLine
var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();
