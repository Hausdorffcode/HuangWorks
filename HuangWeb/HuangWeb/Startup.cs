using HuangWeb.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HuangWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureSimple(IApplicationBuilder app)
        {
            app.UseMyMiddleware(new MyMiddlewareConfigOption("hqm"));

            app.UseMySimpleMiddleware();

            app.Use(async (context, next) =>
            {
                context.Items["info"] += $"<h2>use lambda as middleware {DateTime.Now}</h2>";
                await next();
            });

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                string s = context.Items["info"].ToString();
                await context.Response.WriteAsync(s);
            });
        }
    }
}
