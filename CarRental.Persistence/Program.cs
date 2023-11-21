using CarRental.Persistence;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddSqlServerDbContext<DataBaseContext>("sqldata");

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(DataBaseInitializer.ActivitySourceName));

builder.Services.AddSingleton<DataBaseInitializer>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<DataBaseInitializer>());
builder.Services.AddHealthChecks()
    .AddCheck<DataBaseInitializerHealthCheck>("DbInitializer", null);

var app = builder.Build();

app.MapDefaultEndpoints();

await app.RunAsync();