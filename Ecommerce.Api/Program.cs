using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Product;
using Ecommerce.Application.UseCases.Participant;
using FastEndpoints;
using FastEndpoints.Swagger;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Application.UseCases.Interfaces.Order;
using Ecommerce.Application.UseCases.Order;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura a connection string
var connectionString = builder.Configuration.GetConnectionString("Postgres")
    ?? throw new Exception("Connection string 'Postgres' not found.");

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddScoped<IProductRepository>(sp => new ProductRepository(connectionString,null!));
builder.Services.AddScoped<IParticipantRepository>(sp => new ParticipantRepository(connectionString, null!));
builder.Services.AddScoped<IOrderRepository>(sp => new OrderRepository(connectionString, null!));
builder.Services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
builder.Services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
builder.Services.AddScoped<IParticipantAddUseCase, ParticipantAddUseCase>();
builder.Services.AddScoped<IParticipantGetAllUseCase, ParticipantGetAllUseCase>();
builder.Services.AddScoped<IOrderAddUseCase, OrderAddUseCase>();

var app = builder.Build();

app.UseFastEndpoints().UseSwaggerGen();
app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
