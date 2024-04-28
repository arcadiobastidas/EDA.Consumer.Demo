using System.Reflection;
using Contracts;
using EDA.Consumer.Demo.Application;
using EDA.Consumer.Demo.Infrastructure;
using MassTransit;



var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddApplicationServices();
services.AddInfrastructureServices(builder.Configuration);



services.AddMassTransit(x =>
{
    
    x.SetKebabCaseEndpointNameFormatter();

    // By default, sagas are in-memory, but should be changed to a durable
    // saga repository.
    x.SetInMemorySagaRepositoryProvider();

    var entryAssembly = Assembly.GetEntryAssembly();

    x.AddConsumers(entryAssembly);
    x.AddSagaStateMachines(entryAssembly);
    x.AddSagas(entryAssembly);
    x.AddActivities(entryAssembly);

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq");
        cfg.UseDelayedMessageScheduler();
        cfg.UseMessageRetry(x => x.Interval(5, 1000));
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHealthChecks("/health");

app.MapGet(pattern:"/", () => 
    "I'm Healthy!")
    .WithOpenApi(cfg =>
    {
        cfg.Summary = "Health Check";
        cfg.Description = "Health Check";
        return cfg;
    });


app.Run();

