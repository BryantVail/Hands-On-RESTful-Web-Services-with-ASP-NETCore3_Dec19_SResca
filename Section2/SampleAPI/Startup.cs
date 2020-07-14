using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleAPI.CustomRouting;
using SampleAPI.Filters;
using SampleAPI.Repositories;

namespace SampleAPI
{
    public class Startup
    {
        

        public IConfiguration Configuration { get; }
        //public IWebHostEnvironment Environment {get;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(config => config.Filters.Add(new CustomFilterAsync()));

            //if(Environment.IsDevelopment())
            //{
            //    services.AddTransient<IPaymentService, PaymentService>();

            //}else
            //{
            //    services.AddTransient<IPaymentService, ExternalPaymentService>();
            //}

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("currency", typeof(CurrencyConstraint));
            });

            services
                .AddSingleton<IOrderRepository, MemoryOrderRepository>()
                .AddSingleton<CustomActionFilterAsync>()
                // addControllers() should be last so that all 
                // > other middleware has the chance to run
                .AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();

                // "conventional routing"; define new route template
                // example: https://myhostname/mycontroller/myaction with a controller named MyController and an action named MyAction
                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");



                //alt
                // NOT ReST compliant
                //endpoints.MapControllerRoute("order", "order/giveMeOrders", new { controller = "Order", action = "Get" });

                // DO NOT USE FOR WEB SERVICES (Use 'Attribute Routing')
                //WriteAsync requires: Microsoft.AspNetCore.Http
                //Map{verb}(routeTemplate, RequestDelegate)
                //endpoints.MapGet("order", context => context.Response.WriteAsync("Hi, from GET verb!"));
                //endpoints.MapPost("order", context => context.Response.WriteAsync("Hi, from POST verb!"));

            });
        }
    }
}
