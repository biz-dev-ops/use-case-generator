using System.Collections.Generic;
using Company.Product.Domain.UseCases.Types;

namespace Company.Product.Adapters.Rest.Models
{
    public class GetAnimalsResponse : OffsetResponse
    { 
        public IEnumerable<Animal> Animals { get; set; }
    }
}