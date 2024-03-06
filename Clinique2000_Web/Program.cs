using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Clinique2000_Utility;
using Clinique2000_DataAccess.Data.DbInitializer;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Clinique2000DbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("Clinique2000DbContext") ?? throw new InvalidOperationException("Connection string 'Clinique2000DbContext' not found."));
 });


builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<Clinique2000DbContext>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();




builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});



var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

SeedDatabase();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area=exists}/{controller=Clinique}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "CliniqueAdmin",
    pattern: "{area=exists}/{controller=Clinique}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Utilisateur",
    pattern: "{area=exists}/{controller=Clinique}/{action=Recherche}/{id?}");

app.MapControllerRoute(
    name: "Patient",
    pattern: "{area=exists}/{controller=PlagesHoraires}/{action=Create}/{id}");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Utilisateur}/{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();
app.Run();
