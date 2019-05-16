using Microsoft.AspNetCore.Mvc;
using RestfulBank.API.ApplicationServices;
using RestfulBank.API.Resources;

namespace RestfulBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly ITransfersService _transfersService;

        public TransfersController(ITransfersService transfersService)
        {
            _transfersService = transfersService;
        }

        [HttpPost]
        public IActionResult MakeTransfer([FromBody]Transfer transfer)
        {
            var result = _transfersService.Transfer(transfer.SourceAccountId, transfer.DestinationAccountId, transfer.Amount, transfer.Reason);

            if (result.Status == TransferStatus.Success)
            {
                return NoContent();
            }
            else if (result.Status == TransferStatus.AccountNotFound)
            {
                return NotFound(new AccountNotFoundProblem(result.MissingAccountId));
            }
            else if (result.Status == TransferStatus.DailyQuotaReached)
            {
                return this.BadRequestResource(new DailyQuotaReachedProblem(result.DailyLimit));
            }
            else if (result.Status == TransferStatus.InsufficientFunds)
            {
                return this.BadRequestResource(new InsufficientFundsProblem(result.AvailableFunds));
            }
            else if (result.Status == TransferStatus.AccountDoesNotAllowWithdrawals)
            {
                return this.BadRequestResource(new AccountDoesNotAllowWithdrawalsProblem());
            }
            else //if (result.Status == TransferStatus.InvalidReason)
            {
                return this.BadRequestResource(new InvalidReasonProblem());
            }
        }
    }
}
