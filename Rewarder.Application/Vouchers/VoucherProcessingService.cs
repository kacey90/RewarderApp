using CsvHelper;
using Rewarder.Application.Vouchers.CsvMappers;
using System.Globalization;

namespace Rewarder.Application.Vouchers;

/// <summary>
/// Process csv file and create vouchers
/// </summary>
public class VoucherProcessingService
{
    public List<VoucherRequest> ProcessVouchersFromFile(Stream fileStream)
    {
        List<VoucherRequest> vouchers = new();
        using var reader = new StreamReader(fileStream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<CustomerMap>();
        var records = csv.GetRecords<Customer>().ToList();
        
        foreach (var record in records)
        {
            var (voucherAmount, validity) = CalculateVoucher(record.OrderValue);
            if (voucherAmount > 0)
                vouchers.Add(new VoucherRequest
                {
                    Code = Guid.NewGuid().ToString("N"),
                    CustomerId = record.Id,
                    CustomerFirstName = record.Name,
                    Amount = voucherAmount,
                    ValidityInDays = validity
                });
        }
        
        return vouchers;
    }

    private (decimal voucherAmount, int validity) CalculateVoucher(decimal orderValue)
    {
        return orderValue switch
        {
            var value when value >= 10000 => ((decimal voucherAmount, int validity))(1000, 10),
            var value when value >= 5000 => ((decimal voucherAmount, int validity))(500, 5),
            var value when value >= 1000 => ((decimal voucherAmount, int validity))(100, 1),
            _ => ((decimal voucherAmount, int validity))(0, 0),
        };
    }
}
