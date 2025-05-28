using FastFood.Api.Filters;
using FastFood.Application.Services.CustomerIdentification;
using FastFood.Application.Services.OrderManagement;
using FastFood.Domain.Ports.Common;
using FastFood.Domain.Ports.CustomerIdentification;
using FastFood.Domain.Ports.OrderManagement;
using FastFood.Infra.Data.Context;
using FastFood.Infra.Data.Repositories.Common;
using FastFood.Infra.Data.Repositories.CustomerIdentification;
using FastFood.Infra.Data.Repositories.OrderManagement;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    Environment.GetEnvironmentVariable("DEFAULT_CONNECTION") ??
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FastFoodDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
