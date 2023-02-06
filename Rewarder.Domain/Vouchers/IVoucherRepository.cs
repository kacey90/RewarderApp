namespace Rewarder.Domain.Vouchers;
public interface IVoucherRepository
{
    Task<Voucher> GetByIdAsync(VoucherId id);
    Task AddAsync(Voucher voucher);
    Task AddRangeAsync(IEnumerable<Voucher> vouchers);
    Task<IEnumerable<Voucher>> GetVouchers();
}
