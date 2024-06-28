using Microsoft.OpenApi.Models;
using OpenApiCrudSample.Service;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200").AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigins");

app.MapControllers();

app.Run();
