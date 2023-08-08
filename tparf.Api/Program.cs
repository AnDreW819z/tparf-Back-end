

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using tparf.Api.Common.Errors;
using tparf.Api.Filters;
using tparf.Api.Middleware;
using tparf.Application;
using tparf.Data;
using tparf.Infrastructure;
using tparf.Interfaces;
using tparf.Repository;
using tparf.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, TparfDefaultProblemDetailsFactory>();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);


    // Add services to the container.

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
    builder.Services.AddScoped<IUserRepositories, UserRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.AddCors(c => c.AddPolicy("cors", opt =>
    {
        opt.AllowAnyHeader();
        opt.AllowCredentials();
        opt.AllowAnyMethod();
        opt.WithOrigins(builder.Configuration.GetSection("Cors:Urls").Get<string[]>()!);
    }));
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseCors("cors");
    app.MapControllers();

    app.Run();

    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Map("/error", (HttpContext httpContext) =>
        {
            Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Results.Problem();
        });
    }
}



