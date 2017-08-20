﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HuangWeb.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MySimpleMiddleware
    {
        private readonly RequestDelegate _next;

        public MySimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //httpContext.Response.ContentType = "text/html,charset=utf-8";
            await httpContext.Response.WriteAsync($"<h2>my simpleMiddleWare {GetHashCode()} start do request {httpContext.Request.Path}.</h2>");
            await _next.Invoke(httpContext);
            await httpContext.Response.WriteAsync($"<h2>my simpleMiddleWare {GetHashCode()} end do request {httpContext.Request.Path}.</h2>");
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MySimpleMiddlewareExtensions
    {
        public static IApplicationBuilder UseMySimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MySimpleMiddleware>();
        }
    }
}
