using Rewarder.Domain.Setup;

namespace Rewarder.Domain.Vouchers;
public class VoucherId : TypedIdValueBase
{
    public VoucherId(Guid value) : base(value)
    {
    }
}
