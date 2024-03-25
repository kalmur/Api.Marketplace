namespace Api.Marketplace.Application.Results.Errors
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
