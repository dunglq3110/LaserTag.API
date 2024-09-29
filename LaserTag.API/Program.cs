using LaserTag_API.Core.Data;
using LaserTag_API.Core.Interfaces;
using LaserTag_API.Core.Interfaces.IRepositories;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Repositories;
using LaserTag_API.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
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
                        new string[] {}
                    }
                });
});


builder.Services.AddDbContext<AppDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// DI Containers
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IAttributeService, AttributeService>();
builder.Services.AddScoped<IConfigService, ConfigService>();
builder.Services.AddScoped<ISharedService, SharedService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IHitLogService, HitLogService>();
builder.Services.AddScoped<IRoundService, RoundService>();


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
