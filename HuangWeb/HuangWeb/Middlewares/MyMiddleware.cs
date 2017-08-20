using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HuangWeb.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private MyMiddlewareConfigOption _options;

        public MyMiddleware(RequestDelegate next, MyMiddlewareConfigOption options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //httpContext.Response.ContentType = "text/html, charset=utf-8";
            await httpContext.Response.WriteAsync($"<h2>MyMiddleware {GetHashCode()} do request {_options.GetMessage()}</h2>");
            httpContext.Items["info"] = $"<h2>the info pass through middlewares: {DateTime.Now}</h2>";
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder, MyMiddlewareConfigOption options)
        {
            return builder.UseMiddleware<MyMiddleware>(options);
        }
    }
}
