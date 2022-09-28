using DemoProject.Data;
using DemoProject.Data.GraphQL;
using DemoProject.Repository;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject
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
            services.AddControllers();

            services.AddDbContext < DemoProjectDbContext > (options => 
            options.UseSqlServer(Configuration.GetConnectionString("DemoProject")));

            services.AddScoped<AdminRepo>();
            services.AddScoped<WasteUserRepo>();
            services.AddScoped<WasteRepo>();

            services.AddScoped<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
            services.AddScoped<DemoProjectSchema>();


            //services.AddAuthentication("Bearer")
            //.AddJwtBearer("Bearer", options =>
            
            //{
            //    options.Authority = "https://localhost:5001";
            //    options.Audience = "graphQLApi";
            //});

            services.AddGraphQL().
                AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DemoProjectDbContext dbContext)
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

            app.UseAuthentication();

            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseGraphQL<DemoProjectSchema>();

            app.UseGraphQLPlayground();

            dbContext.Seed();

        }
    }
}
