using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// This format is OK too
// builder.Services.AddDbContext<StoreDbContext>(options =>
// {options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// });


// Be aware, the configuration comes from BUILDER
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

// Inject the implementation of IStoreRepository
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
