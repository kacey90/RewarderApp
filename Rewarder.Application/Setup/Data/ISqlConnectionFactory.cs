using System.Data;

namespace Rewarder.Application.Setup.Data;
public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}
