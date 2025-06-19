using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases;
using Ecommerce.Application.UseCases.Interfaces;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura a connection string
var connectionString = builder.Configuration.GetConnectionString("Postgres")
    ?? throw new Exception("Connection string 'Postgres' not found.");

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddScoped<IProductRepository>(sp => new ProductRepository(connectionString,null!));
builder.Services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
builder.Services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();

var app = builder.Build();

app.UseFastEndpoints().UseSwaggerGen();
app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
