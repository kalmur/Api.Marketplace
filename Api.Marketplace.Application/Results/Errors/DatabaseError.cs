﻿namespace Api.Marketplace.Application.Results.Errors
{
    public class DatabaseError : Error
    {
        public DatabaseError(string errorMessage)
            : base(ErrorType.Database)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
