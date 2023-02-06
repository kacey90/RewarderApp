using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rewarder.Application.Vouchers;
using Rewarder.Application.Vouchers.Queries;

namespace Rewarder.Backend;
internal static class EndpointExtensions
{
    public static void MapAppEndpoints(this WebApplication app)
    {
        app.MapGet("/vouchers", GetAllVouchers)
            .WithName("GetAllVouchers")
            .WithOpenApi();

        app.MapPost("/voucher", CreateVoucher)
            .Accepts<IFormFile>("multipart/form-data")
            .Produces(200)
            .WithName("CreateVoucher")
            .WithOpenApi();
    }

    private static async Task<IResult> GetAllVouchers(IMediator mediator)
    {
        var vouchers = await mediator.Send(new GetAllVouchersQuery());
        return Results.Ok(vouchers);
    }

    private static async Task<IResult> CreateVoucher(IMediator mediator, [FromForm]IFormFile file)
    {
        // make file a stream and pass it to the command
        var command = new CreateVoucherCommand(file.OpenReadStream());
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }
}
