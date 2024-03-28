namespace Api.Marketplace.Domain.Results.Errors
{
    public enum ErrorType
    {
        Api,
        RequestValidation,
        Database,
        NotFound
    }

    public abstract class Error
    {
        protected Error(ErrorType type)
        {
            Type = type;
        }

        public ErrorType Type { get; }
    }
}
