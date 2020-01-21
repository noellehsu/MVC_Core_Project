using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi_TodoApi_Clone.Models;
using CoreWebApi_TodoApi_Clone.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreWebApi_TodoApi_Clone
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
            //���UEntity Framework Core ��InMemoryDatabase(�O�o��InMemory�M��)
            services.AddControllers();

            //���w�ϥ�InMemory �O�����ƮwProvider
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoListDB"));
            services.AddDbContext<EmployeeContext>(option => option.UseSqlServer(_config.GetConnectionString("EmployeeDB_SqlServer")));

            //���URepository
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepositoryAsync>();
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
