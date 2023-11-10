using System;

namespace Company.Product.Domain.UseCases.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
           : this(null) { }

        public NotFoundException(Exception innerException)
            : base("Resource not found.", innerException) { }
    }
}