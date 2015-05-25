using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace Builder.Middleware.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseXHttpHeaderOverride();

            app.UseMiddleware(typeof (MyMiddleware), "No");
        }
    }

    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseXHttpHeaderOverride(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<XhttpHeaderOverrideMiddleware>();
        }
    }

    public class XhttpHeaderOverrideMiddleware
    {
        private readonly RequestDelegate _next;

        public XhttpHeaderOverrideMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var headerValue = httpContext.Request.Headers["X-HTTP-Method-Override"];
            var queryValue = httpContext.Request.Query["X-HTTP-Method-Override"];

            if (!string.IsNullOrEmpty(headerValue))
            {
                httpContext.Request.Method = headerValue;
            }
            else if(!string.IsNullOrEmpty(queryValue))
            {
                httpContext.Request.Method = queryValue;
            }

            return _next.Invoke(httpContext);
        }
    }

    public class MyMiddleware
    {
        private RequestDelegate _next;
        private readonly string _greeting;
        private IServiceProvider _service;

        public MyMiddleware(RequestDelegate next, string greeting, IServiceProvider service)
        {
            _next = next;
            _greeting = greeting;
            _service = service;
        }

        public async Task Invoke(HttpContext httpcontext)
        {
            await httpcontext.Response.WriteAsync(_greeting + ", middleware!\r\n");
            await httpcontext.Response.WriteAsync("This request is a " + httpcontext.Request.Method + "\r\n");
        }
    }
}
