namespace Api.Marketplace.Domain.Results
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

        public static implicit operator Result<TValue, TError>(TValue value)
        {
            return new(value);
        }

        public static implicit operator Result<TValue, TError>(TError error)
        {
            return new(error);
        }

        public TResult Match<TResult>(
            Func<TValue, TResult> success,
            Func<TError, TResult> failure
        )
        {
            return IsError ? failure(_error!) : success(_value!);
        }
    }
}
