using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using HealthChecks.UI.Client;
using MarcakiService.Cross.CommandHandlers;
using MarcakiService.Cross.Extensions;
using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Repository;
using MarcakiService.Repository;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

[assembly: ExcludeFromCodeCoverage]

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().ConfigureHealthChecks(configuration);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateProviderCommandHandler).Assembly);
builder.Services.AddScoped<ReadmodelContext>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.UseHealthChecks("/health", new  HealthCheckOptions
{
    Predicate = p => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });

app.Run();