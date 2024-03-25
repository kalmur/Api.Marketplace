namespace Api.Marketplace.Application.Results
{
    public readonly struct Result<TValue, TError>
    {
        private readonly TValue? _value;
        private readonly TError? _error;

        private Result(TValue value)
        {
            _value = value;
            _error = default;
            IsError = false;
        }

        private Result(TError error)
        {
            _error = error;
            _value = default;
            IsError = true;
        }

        public bool IsError { get; }
        public TValue? Value => _value;
        public TError? Error => _error;

        /// <summary>
        ///     Create the Successful Result.
        /// </summary>
        /// <param name="value">The object denoting a Successful Result.</param>
        public static implicit operator Result<TValue, TError>(TValue value)
        {
            return new(value);
        }

        /// <summary>
        ///     Create the Error Result.
        /// </summary>
        /// <param name="error">The object denoting an Error Result.</param>
        public static implicit operator Result<TValue, TError>(TError error)
        {
            return new(error);
        }

        /// <summary>
        ///     Method for mapping the Successful or Error case to a Result.
        /// </summary>
        /// <typeparam name="TResult">The result required of the actions being passed in.</typeparam>
        /// <param name="success">The action to perform in the case of a Successful Result.</param>
        /// <param name="failure">The action to perform in the case of an Error Result.</param>
        /// <returns>The result object of the actions being passed in.</returns>
        public TResult Match<TResult>(
            Func<TValue, TResult> success,
            Func<TError, TResult> failure
        )
        {
            return IsError ? failure(_error!) : success(_value!);
        }
    }
}
