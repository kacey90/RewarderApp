using Microsoft.AspNetCore.Components.Forms;
using Rewarder.App.Data.Models;
using Rewarder.App.Extensions;
using Rewarder.Shared.Wrapper;
using IResult = Rewarder.Shared.Wrapper.IResult;

namespace Rewarder.App.Data;
internal class RewarderService : IRewarderService
{
    private readonly HttpClient _httpClient;

    public RewarderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult> CreateVouchersFromFile(IBrowserFile file)
    {
        using var content = new MultipartFormDataContent
        {
            { new StreamContent(file.OpenReadStream()), "file", file.Name }
        };
        var response = await _httpClient.PostAsync("/voucher", content);
        return await response.ToResult();
    }

    public async Task<IResult<List<VoucherDto>>> GetVouchers()
    {
        var response = await _httpClient.GetAsync("/vouchers");
        return await response.ToResult<List<VoucherDto>>();
    }
}
