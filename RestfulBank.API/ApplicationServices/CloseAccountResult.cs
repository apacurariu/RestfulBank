using System;

namespace RestfulBank.API.ApplicationServices
{
    public class CloseAccountResult
    {
        public CloseAccountStatus Status { get; private set; }
        public Guid MissingAccountId { get; private set; }

        internal static CloseAccountResult CannotCloseAccount()
        {
            return new CloseAccountResult()
            {
                Status = CloseAccountStatus.AccountCannotBeClosed
            };
        }

        internal static CloseAccountResult Success()
        {
            return new CloseAccountResult()
            {
                Status = CloseAccountStatus.Success
            };
        }

        internal static CloseAccountResult AccountNotFound(Guid accountId)
        {
            return new CloseAccountResult()
            {
                Status = CloseAccountStatus.AccountNotFound,
                MissingAccountId = accountId
            };
        }

        internal static CloseAccountResult AccountIsNotEmpty()
        {
            return new CloseAccountResult()
            {
                Status = CloseAccountStatus.AccountIsNotEmpty,
            };
        }
    }
}
