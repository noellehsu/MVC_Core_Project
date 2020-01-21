using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CoreWebApi_TodoApi.Models;
using CoreWebApi_TodoApi.Repositories;

namespace CoreWebApi_TodoApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //µù¥U¤@¯ëDbContext
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer(_config.GetConnectionString("EmployeeDB_SqlServer")));

            //µù¥U¤@¯ëRepository
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepositoryAsync>();

            //µù¥Uªx«¬Repository
            services.AddDbContext<HRContext>(opt => opt.UseSqlServer(_config.GetConnectionString("EmployeeDB_SqlServer")));
            services.AddScoped(typeof(IGenericRepositoryc<>), typeof(GenericRepositoryAsync<>));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
