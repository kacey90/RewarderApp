using Microsoft.EntityFrameworkCore;
using Rewarder.Domain.Vouchers;

namespace Rewarder.Infrastructure.Database;
internal class VoucherRepository : IVoucherRepository
{
    private readonly RewarderDbContext _dbContext;

    public VoucherRepository(RewarderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Voucher> GetByIdAsync(VoucherId id)
    {
        return await _dbContext.Vouchers.FindAsync(id);
    }

    public async Task AddAsync(Voucher voucher)
    {
        await _dbContext.Vouchers.AddAsync(voucher);
    }

    public async Task AddRangeAsync(IEnumerable<Voucher> vouchers)
    {
        await _dbContext.Vouchers.AddRangeAsync(vouchers);
    }
    
    public async Task<IEnumerable<Voucher>> GetVouchers() => await _dbContext.Vouchers.OrderByDescending(v => v.DateCreated).ToArrayAsync();
}
