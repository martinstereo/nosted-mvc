﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace nosted_dotnet.MVC
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Security set up of HTTP headers

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
            
            // To enforce HTTPS Connection
            app.UseHsts();

        }
    }
}
