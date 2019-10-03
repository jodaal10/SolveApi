using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solve.DM.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Solve.DM.Calculate;
using Solve.BM.Calculate;

namespace Solve.Api
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
            //Configuracion cadena de conexion Entity
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Solve_AuditoriaContext>(options => options.UseSqlServer(connection));
            //Configuracion cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Configuracion inyeccion dependencias.
            services.AddScoped<ICalculateRepository, CalculateRepository>();
            services.AddScoped<IBMCalculate, BMCalculate>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowOrigin");
            app.UseMvc();
        }
    }
}
