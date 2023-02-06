using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rewarder.Domain.Setup;
using Rewarder.Domain.Vouchers;
using Rewarder.Infrastructure.Processing.UoW;
using Rewarder.Infrastructure.Setup;

namespace Rewarder.Infrastructure.Database;
internal class DataAccessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<SqlConnectionFactory>()
        //        .As<ISqlConnectionFactory>()
        //        .WithParameter("connectionString", _databaseConnectionString)
        //        .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<StronglyTypedIdValueConverterSelector>()
                .As<IValueConverterSelector>()
                .SingleInstance();

        builder.RegisterType<VoucherRepository>()
            .As<IVoucherRepository>()
            .InstancePerLifetimeScope();

        builder
            .Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<RewarderDbContext>();
                dbContextOptionsBuilder.UseInMemoryDatabase("RewarderDB");
                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                return new RewarderDbContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}
