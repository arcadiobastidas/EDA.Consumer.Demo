using EDA.Consumer.Demo.Application;
using EDA.Consumer.Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddApplicationServices();
services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHealthChecks("/health");

app.MapGet(pattern:"/health", requestDelegate: async (httpContext) =>
{
    await httpContext.Response.WriteAsync("Healthy");
});

app.Run();

