using System;

namespace Company.Product.Domain.UseCases.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException()
           : this(null) { }

        public NotAuthenticatedException(Exception innerException)
            : base("User must be authenticated to execute this use-case.", innerException) { }
    }
}