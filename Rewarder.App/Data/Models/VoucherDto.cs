namespace Rewarder.App.Data.Models;
public class VoucherDto
{
    //public Guid Id { get; init; }

    public string Code { get; set; }

    public int CustomerId { get; set; }

    public string CustomerFirstName { get; set; }

    public decimal Amount { get; set; }

    public int ValidityInDays { get; set; }

    public DateTime DateCreated { get; set; }
}
