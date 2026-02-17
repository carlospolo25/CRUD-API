
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using NewAppi.Infrastructure.Data;
using NewAppi.Aplication.Service;
using NewAppi.WedAPI.Middlewares;

namespace NewAppi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IProductoService, ProductoService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "NewApi - Productos API",
                    Version = "v1",
                    Description = "API REST para la gestión de productos. " +
                      "Incluye operaciones CRUD completas y está diseñada siguiendo arquitectura por capas.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Carlos Polo",
                        Email = "cp9188825@gmail.com"
                    }
                });
            });
            //Connection tu database
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Defaulconnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "NewAppi v1");
                    options.RoutePrefix = "swagger";

                });

            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
