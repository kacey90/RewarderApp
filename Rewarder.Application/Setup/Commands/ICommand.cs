using MediatR;

namespace Rewarder.Application.Setup.Commands;
public interface ICommand<out TResult> : IRequest<TResult>
{
}
