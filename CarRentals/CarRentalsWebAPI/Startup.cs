using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using CarRentalsWebAPI.Repository;
using CarRentalsWebAPI.Services;
using CarRentalsWebAPI.Validations;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace CarRentalsWebAPI
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarRentalsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CarRentalsDB")));

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IRentalService, RentalService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CarRentalsWebAPI",
                    Version = "v1",
                    Description = "With this API you will be able to manage your Car rental system"
                });

                c.IncludeXmlComments(XmlCommentsFilePath);
            });
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddFluentValidation(
                fv => fv.RegisterValidatorsFromAssemblyContaining<BrandValidator>()
                .RegisterValidatorsFromAssemblyContaining<CarValidator>()
                .RegisterValidatorsFromAssemblyContaining<CustomerValidator>()
                .RegisterValidatorsFromAssemblyContaining<RentalValidator>());
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentalsWebAPI v1"));
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
