using MediatR;
using Microsoft.Extensions.Logging;
using Rewarder.Application.Setup.Commands;
using Rewarder.Application.Vouchers;
using System.Text;
using System.Text.Json;

namespace Rewarder.Infrastructure.Processing.Logging;
internal sealed class LoggingCommandHandlerDecorator<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    private readonly IRequestHandler<TCommand, TResult> _decorated;
    private readonly ILogger<LoggingCommandHandlerDecorator<TCommand, TResult>> _logger;

    public LoggingCommandHandlerDecorator(IRequestHandler<TCommand, TResult> decorated, ILogger<LoggingCommandHandlerDecorator<TCommand, TResult>> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling command {CommandName} with data {@CommandData}", typeof(TCommand).Name, request);

        var result = await _decorated.Handle(request, cancellationToken);

        _logger.LogInformation("Handled command {CommandName} with data {@CommandData}", typeof(TCommand).Name, result);

        return result;
    }

    // serialize to bytes if input is a stream else serialize to string
    private static string Serialize(object? input)
    {
        if (input is CreateVoucherCommand createVoucherCommand)
        {
            using var memoryStream = new MemoryStream();
            createVoucherCommand.FileStream.CopyTo(memoryStream);
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        return JsonSerializer.Serialize(input);
    }
}
