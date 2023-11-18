using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup>  logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("Hello from  1st  Middleware!!!");
                logger.LogInformation("Middleware1  :  Incoming  Request");
                await  next();
                logger.LogInformation("Middleware1  :  Outgoing Responnse");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from  2nd  Middleware!!!");
                logger.LogInformation("Middleware2  :  Incoming  Request");
                await next();
                logger.LogInformation("Middleware2  :  Outgoing Responnse");
            });

            app.Run(async (context) =>
            {
                
                await context.Response.WriteAsync("Hello from  3nd  Middleware!!!");
                logger.LogInformation("Middleware3  : Request hanndled  & Response Produced");
            });
        }
    }
}
