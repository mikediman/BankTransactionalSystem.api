namespace BankTransactionalSystem.Types.Result
{
    public class Result<T>
    {
        public string ErrorMessage { get; set; }
        public int Code { get; set; }
        public T Payload { get; set; }
        public int AppEventId { get; set; }
    }
}
