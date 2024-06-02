using CourseProviderInfrastructure.Data.Contexts;
using CourseProviderInfrastructure.GraphQl;
using CourseProviderInfrastructure.GraphQl.Mutations;
using CourseProviderInfrastructure.GraphQl.ObjectTypes;
using CourseProviderInfrastructure.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddPooledDbContextFactory<DataContext>(x =>
        {
            x.UseCosmos(
    Environment.GetEnvironmentVariable("COSMOS_URI") ?? throw new InvalidOperationException("COSMOS_URI not set."),
    Environment.GetEnvironmentVariable("COSMOS_DBNAME") ?? throw new InvalidOperationException("COSMOS_DBNAME not set.")
).UseLazyLoadingProxies();

            //x.UseCosmos(Environment.GetEnvironmentVariable("COSMOS_URI")!, Environment.GetEnvironmentVariable("COSMOS_DBNAME")!).UseLazyLoadingProxies();
            //var cosmosUri = Environment.GetEnvironmentVariable("COSMOS_URI");
            //var cosmosDbName = Environment.GetEnvironmentVariable("COSMOS_DBNAME");
            //if (string.IsNullOrEmpty(cosmosUri) || string.IsNullOrEmpty(cosmosDbName))
            //{
            //    throw new Exception("Cosmos DB configuration is missing.");
            //}

            //x.UseCosmos(cosmosUri, cosmosDbName).UseLazyLoadingProxies();
        });
        services.AddScoped<ICourseService, CourseService>();

        services.AddGraphQLFunction()
                .AddQueryType<Query>()
                .AddMutationType<CourseMutation>()
                .AddType<CourseType>();

        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        using var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Database.EnsureCreated();
    })
    .Build();

host.Run();
