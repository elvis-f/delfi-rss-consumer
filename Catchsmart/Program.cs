using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Catchsmart.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("CatchsmartIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CatchsmartIdentityDbContextConnection' not found.");

// builder.Services.AddDbContext<CatchsmartIdentityDbContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CatchsmartIdentityDbContext>();

services.AddDbContext<CatchsmartIdentityDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

services.AddDefaultIdentity<CatchsmartUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CatchsmartIdentityDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

services.AddAuthentication().AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"]!;
    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"]!;
});

var app = builder.Build();

// This is for cookies to work with http
app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});

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
