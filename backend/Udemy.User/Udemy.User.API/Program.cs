using Udemy.ServiceDefaults;
using Udemy.User.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddApplication();

builder.AddServiceDefaults();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

app.MapGraphQL("/authentication");

app.Run();
