using JiggysCarRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JiggysCarRental.Utilities;
//using JiggysCarRental.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<CarDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CarConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CarDbContext>().AddDefaultTokenProviders();


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await SeedData.Initialize(serviceProvider);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

