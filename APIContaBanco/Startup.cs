using APIContaBanco.Context;
using APIContaBanco.Models;
using APIContaBanco.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco
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
            //MySQL configs.
            var connectionString = Configuration.GetConnectionString("MySQLConnection");
            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            
            //MongoDB configs.
            services.Configure<BankingOperationsMongoSettings>(Configuration.GetSection("MongoSettings"));
            services.AddSingleton<IBankingOperationsMongoSettings>(s => s.GetRequiredService<IOptions<BankingOperationsMongoSettings>>().Value);
            //services.AddSingleton<IBankingOperationsMongoSettings, BankingOperationsMongoSettings>();
            services.AddSingleton<MongoRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

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
