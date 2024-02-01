using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Api.Endpoints.Users;
using AutomatedLearningSystem.Api.Extensions;
using AutomatedLearningSystem.Application;
using AutomatedLearningSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    await app.ApplyMigrations();
    app.SeedData();

}

app.UseHttpsRedirection();

app.MapEndpoints();


app.Run();


public partial class Program;