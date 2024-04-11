using Application;
using Onion.Architecture.Api.Endpoints;
using Onion.Architecture.Api.Middlewares;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseMiddleware<ApiExceptionMiddleware>();

var endpoints = app.MapGroup("api");

endpoints
    .MapAppointmentCategoryEndpoints()
    .MapAppointmentTypeEndpoints()
    .MapAppointmentEndpoints();

app.Run();