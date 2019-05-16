namespace RestfulBank.API.ApplicationServices
{
    public enum TransferStatus
    {
        Success,
        AccountNotFound,
        InvalidReason,
        DailyQuotaReached,
        InsufficientFunds,
        AccountDoesNotAllowWithdrawals,
    }
}
