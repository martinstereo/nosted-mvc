using nosted_dotnet.MVC.Repositories;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using nosted_dotnet.MVC;
using nosted_dotnet.MVC.Data;
using Microsoft.AspNetCore.Mvc;

public class Program
{
    static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DataContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("MariaDb"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDb"))));

        builder.Services.AddScoped<IProduktRepository, EfProduktRepository>();
        builder.Services.AddScoped<IKundeRepository, EfKundeRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAdresseRepository, EfAdresseRepository>();


        builder.Services.AddScoped<IOrdreRepository, EfOrdreRepository>();
        builder.Services.AddScoped<ISjekklisteRepository, SjekklisteRepository>();
        builder.Services.AddScoped<ISjekkRepository, SjekkRepository>();

        // Add services to the container.
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });

        SetupAuthentication(builder);

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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        //Removing Server Headers 
        //Headers provide information that is better to hide

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
    }


private static void SetupAuthentication(WebApplicationBuilder builder)
{
//Setup for Authentication
builder.Services.Configure<IdentityOptions>(options =>
{
// Default Lockout settings.
options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
options.Lockout.MaxFailedAccessAttempts = 5;
options.Lockout.AllowedForNewUsers = false;
options.SignIn.RequireConfirmedPhoneNumber = false;
options.SignIn.RequireConfirmedEmail = false;
options.SignIn.RequireConfirmedAccount = false;
options.User.RequireUniqueEmail = true;
});

builder.Services
    .AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(o =>
{
o.DefaultScheme = IdentityConstants.ApplicationScheme;
o.DefaultSignInScheme = IdentityConstants.ExternalScheme;

}).AddIdentityCookies(o => { });

builder.Services.AddTransient<IEmailSender, AuthMessageSender>();
}

public class AuthMessageSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine(email);
        Console.WriteLine(subject);
        Console.WriteLine(htmlMessage);
        return Task.CompletedTask;
    }
}