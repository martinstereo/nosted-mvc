using nosted_dotnet.MVC.Repositories;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using nosted_dotnet.MVC;
using nosted_dotnet.MVC.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MariaDb"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDb"))));

builder.Services.AddScoped<IProduktRepository, EfProduktRepository>();
builder.Services.AddScoped<IKundeRepository, EfKundeRepository>();
builder.Services.AddScoped<IAnsattRepository, AnsattRepository>();
builder.Services.AddScoped<IAdresseRepository, EfAdresseRepository>();


builder.Services.AddScoped<IOrdreRepository, EfOrdreRepository>();
builder.Services.AddScoped<ISjekklisteRepository, SjekklisteRepository>();
builder.Services.AddScoped<ISjekkRepository, SjekkRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Removing Server Headers 
//Headers provide information that is better to hide

WebHost.CreateDefaultBuilder(args)
.ConfigureKestrel(c => c.AddServerHeader = false)
.UseStartup<Startup>()
.Build();

app.Run();
