using System;

namespace Company.Product.Domain.UseCases.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException()
           : this(null) { }

        public NotAuthorizedException(Exception innerException)
            : base("User is not authorized to execute this use-case.", innerException) { }
    }
}