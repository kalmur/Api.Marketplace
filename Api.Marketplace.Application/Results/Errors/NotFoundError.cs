namespace Api.Marketplace.Application.Results.Errors
{
    public class NotFoundError : Error
    {
        public NotFoundError(string identifier, string entity)
            : base(ErrorType.NotFound)
        {
            Identifier = identifier;
            Entity = entity;
        }

        public string Identifier { get; }
        public string Entity { get; }
    }
}
