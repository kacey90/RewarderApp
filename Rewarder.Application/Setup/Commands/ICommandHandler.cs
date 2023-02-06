using MediatR;

namespace Rewarder.Application.Setup.Commands;
public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
}
