using Rewarder.Application.Setup.Commands;
using Rewarder.Shared.Wrapper;

namespace Rewarder.Application.Vouchers;

/// <summary>
/// Create voucher command with a csv File stream
/// </summary>
public record CreateVoucherCommand : ICommand<Result<List<VoucherRequest>>>
{
    /// <summary>
    /// Create voucher command with a csv File stream
    /// </summary>
    /// <param name="fileStream">csv file stream</param>
    public CreateVoucherCommand(Stream fileStream)
    {
        FileStream = fileStream;
    }

    /// <summary>
    /// csv file stream
    /// </summary>
    public Stream FileStream { get; }
}
