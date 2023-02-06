using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rewarder.Infrastructure;

namespace Rewarder.IntegrationTests;
public class TestBase
{
    protected IServiceProvider ServiceProvider { get; private set; }
    
    public async Task BuildDependencies()
    {
        var hostBuilder = Host.CreateDefaultBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterApplicationInfrastructure();
            });

        using var host = await hostBuilder.StartAsync();
        using var scope = host.Services.CreateScope();
        ServiceProvider = scope.ServiceProvider;
    }
}
