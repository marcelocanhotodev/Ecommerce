using Ecommerce.Api.Infrastructure;
using Ecommerce.Infrastructure.Database;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddUseCases(builder.Configuration);
DatabaseMigration.Run(builder.Configuration);
var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();
app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
