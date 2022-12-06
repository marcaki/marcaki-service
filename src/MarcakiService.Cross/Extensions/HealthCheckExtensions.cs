using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MarcakiService.Cross.Extensions;

public static class HealthCheckExtensions
{
    public static void ConfigureHealthChecks(this IHealthChecksBuilder builder, IConfiguration configuration)
    {
        builder.AddCheck("self", () => HealthCheckResult.Healthy());
        builder.AddSqlServer(
            connectionString: configuration["ConnectionStrings:MarcakiDb"],
            name: "MarcakiDb"
        );
        builder.Services.AddHealthChecksUI(options =>
        {
            options.SetEvaluationTimeInSeconds(int.Parse(configuration["HealthCheckConfig:EvaluationTimeInSeconds"]));
            options.MaximumHistoryEntriesPerEndpoint(int.Parse(configuration["HealthCheckConfig:MaximumHistoryEntriesPerEndpoint"]));
            options.AddHealthCheckEndpoint(configuration["HealthCheckConfig:Description"], configuration["HealthCheckConfig:Url"]);
        })
        .AddInMemoryStorage();
    }
}