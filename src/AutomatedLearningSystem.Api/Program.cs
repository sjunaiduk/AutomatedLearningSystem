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
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddCors();

builder.Services.AddAuthentication(AuthConstants.DefaultCookieScheme)
    .AddCookie(AuthConstants.DefaultCookieScheme, opt =>
    {
        opt.Events.OnRedirectToAccessDenied = context =>
        {
            return Task.FromResult(context.Response.StatusCode =
            StatusCodes.Status401Unauthorized);
        };
        opt.Events.OnRedirectToLogin = context => Task.FromResult(context.Response.StatusCode = StatusCodes.Status401Unauthorized);
    });


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

app.UseCors(cp =>
{
    cp.WithOrigins("http://localhost:5173");
    cp.WithOrigins("http://localhost:5174");
    cp.AllowAnyMethod();
    cp.AllowCredentials();
    cp.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();
app.MapControllers();

app.Run();


public partial class Program;