using Company.Product.Domain.UseCases.Types;

namespace Company.Product.Adapters.Rest.Models
{
    public class GetAnimalResponse : Response
    { 
        public Animal Animal { get; set; }
    }
}