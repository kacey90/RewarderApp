using Autofac;
using Rewarder.Application.Vouchers;
using Rewarder.Infrastructure.Database;
using Rewarder.Infrastructure.Processing;

namespace Rewarder.Infrastructure;
public static class AutofacBuilderExtensions
{
    public static void RegisterApplicationInfrastructure(this ContainerBuilder builder)
    {
        builder.RegisterModule(new DataAccessModule());
        builder.RegisterModule(new MediatorModule());
        builder.RegisterModule(new ProcessingModule());

        builder.RegisterType<VoucherProcessingService>().InstancePerDependency();
    }
}
