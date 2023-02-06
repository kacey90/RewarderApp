using Rewarder.Domain.Setup;

namespace Rewarder.Domain.Vouchers;
public class Voucher : IAggregateRoot
{
    public VoucherId Id { get; private set; }

    public string Code { get; private set; }

    public int CustomerId { get; private set; }

    public string CustomerFirstName { get; private set; }

    public decimal Amount { get; private set; }

    public int ValidityInDays { get; private set; }

    public DateTime DateCreated { get; private set; }
    
    private Voucher() { }

    private Voucher(
        string code,
        int customerId,
        string customerFirstName,
        decimal amount,
        int validityInDays)
    {
        Id = new VoucherId(Guid.NewGuid());
        Code = code;
        CustomerId = customerId;
        CustomerFirstName = customerFirstName;
        Amount = amount;
        ValidityInDays = validityInDays;
        DateCreated = DateTime.UtcNow;
    }

    public static Voucher Create(string code,
        int customerId,
        string customerFirstName,
        decimal amount,
        int validityInDays) => new(code, customerId, customerFirstName, amount, validityInDays);

}
