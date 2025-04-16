using Infra.Data.Services;
using Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Wrcelo.VrumApp.Application.Services;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;
using Wrcelo.VrumApp.Infra.Data.Configs;
using Wrcelo.VrumApp.Infra.Data.Context;
using Wrcelo.VrumApp.Infra.Data.Repository;


namespace Wrcelo.VrumApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApiContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VrumApp API", Version = "v1" });


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT no formato: Bearer {seu_token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
                        Array.Empty<string>()
                    }
                });
            });

            //Console.WriteLine($"Ambiente atual: {builder.Environment.EnvironmentName}");

            var rabbitConfig = builder.Configuration.GetSection("RabbitMQConfig").Get<RabbitMQConfig>();
            var minioConfig = builder.Configuration.GetSection("MinioConfig").Get<MinioConfiguration>();

            builder.Services.AddSingleton(rabbitConfig);
            builder.Services.AddSingleton(minioConfig);

            builder.Services.AddSingleton<RabbitMQService>();
            builder.Services.AddSingleton<MinioStorageService>();


            builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IDeliveryDriverService, DeliveryDriverService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRentalService, RentalService>();

            builder.Services.AddScoped<IMotorcycleNotificationRepository, MotorcycleNotificationRepository>();
            builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IDeliveryDriverRepository, DeliveryDriverRepository>();
            builder.Services.AddScoped<IRentalRepository, RentalRepository>();

            builder.Services.AddHostedService<RabbitMQConsumer>();




            // CONFIGURAÇÃO DE AUTENTICAÇÃO JWT ABAIXO
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var secretKey = jwtSettings["Key"];

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApiContext>();
                    context.Database.Migrate();

                    var userRepo = services.GetRequiredService<IUserRepository>();
                    var authService = services.GetRequiredService<IAuthService>();

                    var existingAdmin = userRepo.GetByEmailAsync("admin@vrum.com").GetAwaiter().GetResult();
                    if (existingAdmin is null)
                    {
                        var adminDto = new UserDTO
                        {
                            Email = "admin@vrum.com",
                            Name = "admin",
                            Password = "vrum123",
                            Role = "Admin"
                        };

                        authService.RegisterAsync(adminDto, null).GetAwaiter().GetResult();
                        Console.WriteLine("Usuário admin criado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Usuário admin já existe.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inicializar a aplicação: {ex.Message}");
                }
            }


            if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (!app.Environment.IsEnvironment("Docker"))
            {
                app.UseHttpsRedirection();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
