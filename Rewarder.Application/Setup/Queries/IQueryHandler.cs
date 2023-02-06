using MediatR;

namespace Rewarder.Application.Setup.Queries;
public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{

}
