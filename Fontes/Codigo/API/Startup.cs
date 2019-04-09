using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Context;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace API
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
           // Input connection by DI
            services.AddDbContext<DataAccessContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection")));


            // Configurando o serviço de documentação do Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "POC DDD",
            //            Version = "v1",
            //            Description = "Exemplo de API REST criada com o ASP.NET Core",
            //            Contact = new Contact
            //            {
            //                Name = "Eduardo Alcantara de Oliveira",
            //                Url = "https://github.com/eoalcantara"
            //            }
            //        });

            //    string caminhoAplicacao =
            //        PlatformServices.Default.Application.ApplicationBasePath;
            //    string nomeAplicacao =
            //        PlatformServices.Default.Application.ApplicationName;
            //    string caminhoXmlDoc =
            //        Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            //    c.IncludeXmlComments(caminhoXmlDoc);
            //});

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseCors();

            // Ativando middlewares para uso do Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json",
            //        "POC DDD Rest");
            //});


        }
    }
}
