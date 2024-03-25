using Api.Marketplace.Application;
using Api.Marketplace.Persistence;
using Microsoft.OpenApi.Models;
using HttpResponse = Api.Marketplace.WebApi.Services.HttpResponse;
using IHttpResponse = Api.Marketplace.WebApi.Services.Interfaces.IHttpResponse;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(b =>
{
    b.SwaggerDoc("v1", new OpenApiInfo { Title = "Api.Marketplace", Version = "v1"});
});

builder.Services
    .AddApplication(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddScoped<IHttpResponse, HttpResponse>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
