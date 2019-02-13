using AutoMapper;
using EVCapital.CodingTask.Api.ViewModels;
using EVCapital.CodingTask.BusinessLayer;
using EVCapital.CodingTask.Core;
using EVCapital.CodingTask.Core.DomainModels;
using EVCapital.CodingTask.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NJsonSchema;
using NSwag.AspNetCore;

namespace EVCapital.CodingTask.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.TryAddSingleton<IFundingService, FundingService>();
            services.TryAddSingleton<IFundingRepository, FundingInMemoryRepository>();

            services.TryAddSingleton(
                provider => new MapperConfiguration(o =>
                {
                    o.CreateMap<Funding, FundingModel>();
                }).CreateMapper());

            services.AddSwaggerDocument(document =>
            {
                document.PostProcess = doc =>
                {
                    doc.Info.Version = "v1";
                    doc.Info.Title = "Funding API";
                    doc.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Anton Tkachov",
                        Email = "ant.tkachov@gmail.com"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.WithOrigins("http://localhost:4444")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi3();
        }
    }
}
