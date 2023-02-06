using Rewarder.Application.Setup.Commands;
using Rewarder.Domain.Vouchers;
using Rewarder.Shared.Wrapper;

namespace Rewarder.Application.Vouchers;
internal class CreateVoucherCommandHandler : ICommandHandler<CreateVoucherCommand, Result<List<VoucherRequest>>>
{
    private readonly VoucherProcessingService _voucherProcessingService;
    private readonly IVoucherRepository _voucherRepository;

    public CreateVoucherCommandHandler(
        VoucherProcessingService voucherProcessingService,
        IVoucherRepository voucherRepository)
    {
        _voucherProcessingService = voucherProcessingService;
        _voucherRepository = voucherRepository;
    }

    public async Task<Result<List<VoucherRequest>>> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
    {
        List<VoucherRequest> vouchers = _voucherProcessingService.ProcessVouchersFromFile(request.FileStream);

        var voucherObjs = vouchers.Select(v => Voucher.Create(v.Code, v.CustomerId, v.CustomerFirstName, v.Amount, v.ValidityInDays));
        await _voucherRepository.AddRangeAsync(voucherObjs);
        
        return Result<List<VoucherRequest>>.Success(vouchers, "Vouchers created successfully.");
    }
}
