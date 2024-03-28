namespace Api.Marketplace.Domain.Results.Errors
{
    public class RequestValidationError : Error
    {
        public RequestValidationError(string errorMessage)
        : base(ErrorType.RequestValidation)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}
