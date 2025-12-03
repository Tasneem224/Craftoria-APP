
using Abstraction_Layer;
using CloudinaryDotNet;
using Domian_Layer.Contracts;
using Domian_Layer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Presistence.Data.Contexts;
using Scalar.AspNetCore;
using Service_Layer;

namespace Craftoria_APP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Connection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    )
                );
            });

            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<StoreDbContext>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();


            var cloudinaryUrl = builder.Configuration["Cloudinary:CloudinaryUrl"];
            Cloudinary cloudinary = new Cloudinary(cloudinaryUrl);
            builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();

            cloudinary.Api.Secure = true;
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
                await seeder.IdentityDataSeedingAsync();
            }

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json","Production");
                options.RoutePrefix = string.Empty;
            });

            }
                    //}


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
