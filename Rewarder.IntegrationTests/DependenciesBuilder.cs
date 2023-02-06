using Autofac;
using Rewarder.Infrastructure;

namespace Rewarder.IntegrationTests;
internal class DependenciesBuilder : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterApplicationInfrastructure();
    }
}
