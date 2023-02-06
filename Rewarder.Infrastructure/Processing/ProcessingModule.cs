using Autofac;
using MediatR;
using Rewarder.Application.Setup.Commands;
using Rewarder.Infrastructure.Processing.Logging;
using Rewarder.Infrastructure.Processing.UoW;

namespace Rewarder.Infrastructure.Processing;
internal class ProcessingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGenericDecorator(
            typeof(UnitOfWorkCommandHandlerDecorator<,>),
            typeof(IRequestHandler<,>));
        
        builder.RegisterGenericDecorator(
            typeof(LoggingCommandHandlerDecorator<,>),
            typeof(IRequestHandler<,>));
    }
}
