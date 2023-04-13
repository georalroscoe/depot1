using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using Application;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using depot.Models;
using Application.Interfaces;

namespace PrivateWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DepotContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WbacStateEngineContext")));
            services.AddScoped<DbContext, DepotContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBatchProducts, ProductBatcher>();
            services.AddScoped<IGenericRepository<WarehouseBatchContent>, GenericRepository<WarehouseBatchContent>>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseMvc();
        }*/
    }
}
