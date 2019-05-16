namespace RestfulBank.API.Domain
{
    public enum WithdrawStatus
    {
        Success,
        DailyQuotaReached,
        InsufficientFunds,
        AccountDoesNotAllowWithdrawals,
    }
}
