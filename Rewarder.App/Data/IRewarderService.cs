using Microsoft.AspNetCore.Components.Forms;
using Rewarder.App.Data.Models;
using Rewarder.Shared.Wrapper;
using IResult = Rewarder.Shared.Wrapper.IResult;

namespace Rewarder.App.Data;
internal interface IRewarderService
{
    public Task<IResult<List<VoucherDto>>> GetVouchers();

    public Task<IResult> CreateVouchersFromFile(IBrowserFile file);
}
