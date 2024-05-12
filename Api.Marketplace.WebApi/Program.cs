using Api.Marketplace.Application;
using Api.Marketplace.Application.Extensions;
using Api.Marketplace.Persistence;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;
using HttpResponse = Api.Marketplace.WebApi.Services.HttpResponse;
using IHttpResponse = Api.Marketplace.WebApi.Services.Interfaces.IHttpResponse;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CorrelationIdActionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(b =>
{
    b.SwaggerDoc("v1", new OpenApiInfo { Title = "Api.Marketplace", Version = "v1"});
});

builder.Services
    .AddApplication(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddCors();

builder.Services
    .AddScoped<IHttpResponse, HttpResponse>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHsts();

app.UseHttpsRedirection();

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage(Justification = "Exists for WebApplicationFactory Testing")]
public partial class Program
{
}