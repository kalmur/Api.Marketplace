namespace Api.Marketplace.Application.Results.Errors
{
    /// <summary>
    ///     The possible Error Types.
    /// </summary>
    public enum ErrorType
    {
        Api,
        RequestValidation,
        Database,
        NotFound
    }

    /// <summary>
    ///     Base error class.
    /// </summary>
    public abstract class Error
    {
        protected Error(ErrorType type)
        {
            Type = type;
        }

        public ErrorType Type { get; }
    }
}
