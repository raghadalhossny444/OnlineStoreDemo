using OnlineStore.DataAccess.Data;
using OnlineStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.repositories;
using OnlineStore.BusineesLogic.Managers;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Razor view custom location BEFORE app is built
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/Presentation/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Presentation/Views/Shared/{0}.cshtml");
    });

// ✅ Add services to the container BEFORE builder.Build()
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductsDb"));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<productManager>();

// ✅ Build the app AFTER all services are registered
var app = builder.Build();

// ✅ Seed data (optional but before middleware)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Products.AddRange(
        new Product { Name = "Laptop" },
        new Product { Name = "Phone" },
        new Product {Name = "coffee"}
    );
    db.SaveChanges();
}

// ✅ Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Set up routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
