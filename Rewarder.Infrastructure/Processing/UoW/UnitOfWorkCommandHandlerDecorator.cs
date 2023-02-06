using MediatR;
using Rewarder.Application.Setup.Commands;
using Rewarder.Domain.Setup;

namespace Rewarder.Infrastructure.Processing.UoW;
internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    private readonly IRequestHandler<TCommand, TResult> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(IRequestHandler<TCommand, TResult> decorated, IUnitOfWork unitOfWork)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var result = await _decorated.Handle(request, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}
