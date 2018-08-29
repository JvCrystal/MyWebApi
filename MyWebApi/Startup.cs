using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using MyWebApi.Entity;
using Swashbuckle.AspNetCore.Swagger;

namespace MyWebApi
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
            services.AddDbContext<MyContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.1.0",
                    Title = "My WebAPI",
                    Description = "框架集合",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Crystal", Email = "jv_network@outlook.com", Url = "https://www.cnblogs.com/Ingenta/" }
                });
                //添加注释服务
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var apiXmlPath = Path.Combine(basePath, "APIHelp.xml");
                var entityXmlPath = Path.Combine(basePath, "EntityHelp.xml");
                c.IncludeXmlComments(apiXmlPath);
                //添加对控制器的标签(描述)
                c.DocumentFilter<SwaggerDocTag>();
                //添加对实体的描述
                c.IncludeXmlComments(entityXmlPath);                
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion

            app.UseMvc();
        }
    }
}
