namespace RestfulBank.API.ApplicationServices
{
    public enum WithdrawStatus
    {
        Success,
        AccountNotFound,
        DailyQuotaReached,
        InsufficientFunds,
        AccountDoesNotAllowWithdrawals,
    }
}
