using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nosted_dotnet.MVC;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NostedDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN"; // Customize the header name if needed
});

builder.Services.AddTransient<IUserRepository, UserRepository>();






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

// To enforce HTTPS Connection
app.UseHsts();

// Enable anti-forgery token validation
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Security setup of HTTP headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Xss-Protection", "1");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add(
        "Content-Security-Policy",
        "default-src 'self';" +
        "img-src 'self';" +
        "font-src 'self';" +
        "style-src 'self';" +
        "script-src 'self';" +
        "frame-src 'self'; " +
        "connect-src 'self';");
    await next();
});


app.Run();
