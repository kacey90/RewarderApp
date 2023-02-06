using System.Text.Json.Serialization;

namespace Rewarder.Application.Vouchers.Queries;

public record VoucherDto
{
    [JsonConstructor]
    public VoucherDto(
        Guid id,
        string code,
        int customerId,
        string customerFirstName,
        decimal amount,
        int validityInDays,
        DateTime dateCreated)
    {
        Id = id;
        Code = code;
        CustomerId = customerId;
        CustomerFirstName = customerFirstName;
        Amount = amount;
        ValidityInDays = validityInDays;
        DateCreated = dateCreated;
    }

    public Guid Id { get; }
    
    public string Code { get; }

    public int CustomerId { get; }

    public string CustomerFirstName { get; }

    public decimal Amount { get; }

    public int ValidityInDays { get; }

    public DateTime DateCreated { get; }
}