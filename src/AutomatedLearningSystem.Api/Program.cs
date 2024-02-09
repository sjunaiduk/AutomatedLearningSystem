using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Api.Extensions;
using AutomatedLearningSystem.Application;
using AutomatedLearningSystem.Infrastructure;
using AutomatedLearningSystem.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();


builder.Services.AddAuthentication(AuthConstants.DefaultCookieScheme)
    .AddCookie(AuthConstants.DefaultCookieScheme);


builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy(AuthConstants.Policies.Privileged, pb =>
    {
        pb.RequireRole(AuthConstants.Roles.Admin)
            .RequireAuthenticatedUser();
    });

    opt.AddPolicy(AuthConstants.Policies.Protected, pb =>
    {
        pb.RequireRole(AuthConstants.Roles.Admin, AuthConstants.Roles.Student)
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

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthenticatedUserProvider();

app.MapEndpoints();
app.MapRazorPages();

app.Run();


public partial class Program;