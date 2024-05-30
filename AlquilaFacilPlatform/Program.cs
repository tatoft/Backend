using AlquilaFacilPlatform.Locals.Application.Internal.CommandServices;
using AlquilaFacilPlatform.Locals.Application.Internal.QueryServices;
using AlquilaFacilPlatform.Locals.Domain.Repositories;
using AlquilaFacilPlatform.Locals.Domain.Services;
using AlquilaFacilPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;
using AlquilaFacilPlatform.Locals.Interfaces.ACL;
using AlquilaFacilPlatform.Locals.Interfaces.ACL.Services;
using AlquilaFacilPlatform.Shared.Domain.Repositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "AlquilaFacil.API",
                Version = "v1",
                Description = "Alquila Facil API",
                TermsOfService = new Uri("https://alquila-facil.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Alquila Facil",
                    Email = "contact@alquilaf.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<ILocalCommandService, LocalCommandService>();
builder.Services.AddScoped<ILocalQueryService, LocalQueryService>();
builder.Services.AddScoped<ILocalsContextFacade, LocalsContextFacade>();
builder.Services.AddScoped<ILocalRepository, LocalRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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