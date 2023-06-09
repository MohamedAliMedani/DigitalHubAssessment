using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using src.GenericRepo;
using src.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApiVersioning(config =>
               {
                   // Specify the default API Version as 1.0
                   config.DefaultApiVersion = new ApiVersion(1, 0);
                   // If the client hasn't specified the API version in the request, use the default API version number
                   config.AssumeDefaultVersionWhenUnspecified = true;
                   // Advertise the API versions supported for the particular endpoint
                   config.ReportApiVersions = true;
               });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowCors",
                builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:3000")
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
                });
        });
        #region Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Assessment APIs Reference",
            });

            c.AddSecurityDefinition(
            "token",
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                Name = HeaderNames.Authorization
            }
                );
            c.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "token"
                            },
                        },
                        Array.Empty<string>()
                    }
            }
                );
        });
        #endregion Swagger

        builder.Services.AddDbContext<InstabugBackendContext>(options =>
          options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowCors");
        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}