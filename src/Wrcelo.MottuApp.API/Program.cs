
using Microsoft.EntityFrameworkCore;
using Wrcelo.VrumApp.Application.Services;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;
using Wrcelo.VrumApp.Infra.Data.Context;

namespace Wrcelo.VrumApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApiContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
            builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
