using MediatR;

namespace Rewarder.Application.Setup.Queries;
public interface IQuery<out TResult> : IRequest<TResult>
{
}
