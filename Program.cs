
using EasyRepair.Data;
using EasyRepair.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC: mantiene i controller e le viste Razor
builder.Services.AddControllersWithViews();

// Configurazione locale
builder.Configuration.AddJsonFile(
    "appsettings.Local.Json",
    optional: true,
    reloadOnChange: true
);

// Entity Framework Core
builder.Services.AddDbContext<EasyRepairContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnectionString")
    )
);

// ASP.NET Core Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    option.Password.RequiredLength = 8;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<EasyRepairContext>()
.AddDefaultTokenProviders();


// CORS: React chiama direttamente il backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("AllowReact");

app.UseAuthentication();
app.UseAuthorization();

// File statici
app.MapStaticAssets();

// Endpoint per i controller API
app.MapControllers();

// Rotte MVC tradizionali, incluse le viste Razor
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
