namespace RapidPay.Domain.Validations
{
    public class ValidationMessage
    {
        public ValidationMessage(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}