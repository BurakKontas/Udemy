using Udemy.ServiceDefaults;
using Udemy.User.API;
using Udemy.User.Application;
using Udemy.User.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddInfrastructure();

builder.Services.AddProblemDetails();
builder.Services.AddAPI();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL("/authentication")
    .CacheOutput();

app.Run();
