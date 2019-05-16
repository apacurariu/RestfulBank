namespace RestfulBank.API.ApplicationServices
{
    public enum CloseAccountStatus
    {
        Success,
        AccountNotFound,
        AccountIsNotEmpty,
        AccountCannotBeClosed
    }
}
