using CsvHelper.Configuration;

namespace Rewarder.Application.Vouchers.CsvMappers;
internal class CustomerMap : ClassMap<Customer>
{
    public CustomerMap()
    {
        Map(m => m.Id).Name("Customer ID");
        Map(m => m.Name).Name("Customer First Name");
        Map(m => m.OrderValue).Name("Order Value");
    }
}

internal record Customer 
{
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal OrderValue { get; init; }
}

