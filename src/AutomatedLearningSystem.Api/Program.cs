using System.Reflection.Metadata.Ecma335;
using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Api.Endpoints.Users;
using AutomatedLearningSystem.Api.Extensions;
using AutomatedLearningSystem.Application;using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", opt =>
    {
        //opt.Events.OnRedirectToLogin = ctx =>
        //{
        //    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //    return Task.CompletedTask;
        //};
    });

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("protected", pb =>
    {
        pb.RequireRole("admin")
            .RequireAuthenticatedUser();
    });

});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();


public partial class Program;