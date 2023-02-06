namespace Rewarder.Application.Vouchers;
public record VoucherRequest
{
    internal string Code { get; init; }

    internal int CustomerId { get; init; }

    internal string CustomerFirstName { get; init; }

    internal decimal Amount { get; init; }

    internal int ValidityInDays { get; init; }
}
