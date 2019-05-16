using System;

namespace RestfulBank.API.ApplicationServices
{
    public interface ITransfersService
    {
        TransferResult Transfer(Guid sourceAccountId, Guid destinationAccountId, double amount, string reason);
    }
}