using Events.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TickerService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddHostedService<TickerBackgroundService>();

var app = builder.Build();

app.Run();