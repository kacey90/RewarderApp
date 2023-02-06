using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rewarder.Application.Vouchers;
using Rewarder.Application.Vouchers.Queries;

namespace Rewarder.IntegrationTests;
public class CreateVoucherTests : TestBase
{
    [Fact]
    public async Task CreateVoucherCommand_Works()
    {
        await BuildDependencies();
        
        // Arrange
        var mockStream = new Mock<Stream>();
        var data = "Customer ID,Customer First Name,Order Value\n" +
                   "1,Chidubem,8500\n" +
                   "2,Kenechukwu,4600\n" +
                   "3,Adewale,7000\n" +
                   "4,Fikayo,3200\n" +
                   "5,Lisa,12000\n";
        using var ms = new MemoryStream();
        using var writer = new StreamWriter(ms);
        writer.Write(data);
        writer.Flush();
        ms.Position = 0;
        
        var command = new CreateVoucherCommand(ms);

        // Act
        var mediator = ServiceProvider.GetRequiredService<IMediator>();
        var result = await mediator.Send(command);

        // Assert
        Assert.True(result.Succeeded);
        Assert.True(result.Data.Count > 0);
    }

    [Fact]
    public async Task GetAllVouchersQuery_Works()
    {
        await BuildDependencies();

        var query = new GetAllVouchersQuery();

        var mediator = ServiceProvider.GetRequiredService<IMediator>();
        var result = await mediator.Send(query);

        Assert.True(result.Succeeded);
        Assert.True(result.Data.Count > 0);
    }
}
