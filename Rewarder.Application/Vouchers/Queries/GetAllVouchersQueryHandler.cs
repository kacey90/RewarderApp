using Rewarder.Application.Setup.Queries;
using Rewarder.Domain.Vouchers;
using Rewarder.Shared.Wrapper;

namespace Rewarder.Application.Vouchers.Queries;
internal class GetAllVouchersQueryHandler : IQueryHandler<GetAllVouchersQuery, Result<List<VoucherDto>>>
{
    private readonly IVoucherRepository _voucherRepository;
    public GetAllVouchersQueryHandler(IVoucherRepository voucherRepository)
    {
        _voucherRepository = voucherRepository;
    }
    public async Task<Result<List<VoucherDto>>> Handle(GetAllVouchersQuery request, CancellationToken cancellationToken)
    {
        var vouchers = (await _voucherRepository.GetVouchers()).ToList();

        return await Result<List<VoucherDto>>.SuccessAsync(vouchers.Select(x 
            => new VoucherDto(x.Id.Value, x.Code, x.CustomerId, x.CustomerFirstName, x.Amount, 
                x.ValidityInDays, x.DateCreated)).ToList());
    }
}
