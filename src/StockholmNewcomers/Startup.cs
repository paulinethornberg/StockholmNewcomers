using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StockholmNewcomers.Models.Entities;

namespace StockholmNewcomers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=StockholmForNewcomers;Integrated Security=True;Pooling=False";
            services.AddDbContext<StockholmForNewcomersContext>();
            services.AddDbContext<IdentityDbContext>(
                o => o.UseSqlServer(connString));

            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequiredLength = 6;
                o.Password.RequireDigit = false;
                o.Cookies.ApplicationCookie.LoginPath = "/account/login";
            })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
            //}
            //else
            ////    app.UseExceptionHandler("/Error/ServerError");

            //app.UseStatusCodePagesWithRedirects("/Error/HttpError({0}");
            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
        }
    }
}
