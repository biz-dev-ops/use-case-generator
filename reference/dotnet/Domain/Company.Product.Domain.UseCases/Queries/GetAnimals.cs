using Company.Product.Domain.UseCases.Bus;
using Company.Product.Domain.UseCases.Types;

using System.Collections.Generic;

namespace Company.Product.Domain.UseCases.Queries
{
    public class GetAnimals : IQuery<IEnumerable<Animal>>
    {
        public string Filter { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}