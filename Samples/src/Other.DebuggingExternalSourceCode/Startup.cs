using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel.Internal;
using Microsoft.Framework.ConfigurationModel.Json;

namespace Other.DebuggingExternalSourceCode
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            var configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            configuration.AddEnvironmentVariables();
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action}");
                routes.MapRoute(
                    "controllerActionRoute",
                    "{controller}/{action}",
                    new { controller = "Home", action = "Index" },
                    constraints: null,
                    dataTokens: new { NameSpace = "default" });

                routes.MapRoute(
                    "controllerRoute",
                    "{controller}",
                    new { controller = "Home" });
            });
        }
    }
}
