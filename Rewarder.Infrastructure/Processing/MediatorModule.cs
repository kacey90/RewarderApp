using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Rewarder.Application.Setup.Commands;

namespace Rewarder.Infrastructure.Processing;
internal class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(ICommand<>).Assembly;
        builder.RegisterMediatR(MediatRConfigurationBuilder
            .Create(assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build());
    }
}
