namespace RestfulBank.API.Domain
{
    public enum TransferStatus
    {
        Success,
        InvalidReason,
        DailyQuotaReached,
        InsufficientFunds,
        AccountDoesNotAllowWithdrawals,
    }
}
