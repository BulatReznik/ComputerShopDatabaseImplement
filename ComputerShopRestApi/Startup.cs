using ComputerShopBusinessLogics.BusinessLogics;
using ComputerShopContracts.BusinessLogicsContracts;
using ComputerShopContracts.StorageContracts;
using ComputerShopDatabaseImplement.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepairBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopRestApi
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
            services.AddTransient<ISalesmanStorage, SalesmanStorage>();
            services.AddTransient<IRequestStorage, RequestStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IConsignmentStorage, ConsignmentStorage>();
            //services.AddTransient<IEmployeeStorage, EmployeeStorage>();
            //services.AddTransient<IPersonalBuildStorage, PersonalBuildStorage>();
            //services.AddTransient<IComponentStorage, ComponentStorage>();
            //services.AddTransient<IFinalProductStorage, FinalProductStorage>();

            services.AddTransient<ISalesmanLogic, SalesmanLogic>();
            services.AddTransient<IRequestLogic, RequestLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IConsignmentLogic, ConsignmentLogic>();
            //services.AddTransient<IEmployeeLogic, EmployeeLogic>();
            //services.AddTransient<IPersonalBuildLogic, PersonalBuildLogic>();
            //services.AddTransient<IComponentLogic, ComponentLogic>();
            //services.AddTransient<IFinalProductLogic, FinalProductLogic>();
            //services.AddTransient<IReportLogic, ReportLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ComputerShopRestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComputerShopRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
