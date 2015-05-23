using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace Builder.Filtering.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(next => context => Filter(context, next));

            app.Run(HelloBoyceAsync);
        }

        public async Task Filter(HttpContext context, RequestDelegate next)
        {
            var body = context.Response.Body;
            var buffer = new MemoryStream();
            context.Response.Body = buffer;

            try
            {
                context.Response.Headers["CustomHeader"] = "My Header";

                await context.Response.WriteAsync("Before \r\n");
                await next(context);
                await context.Response.WriteAsync("After \r\n");

                buffer.Position = 0;
                await buffer.CopyToAsync(body);
            }
            finally
            {
                context.Response.Body = body;
            }
        }

        public async Task HelloBoyceAsync(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Hello BoyceLyu!");
        }
    }
}
