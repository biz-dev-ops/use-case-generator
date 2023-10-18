using System.Collections.Generic;

namespace Company.Product.Adapters.Rest.Models
{
    public class Response
    { 
        public IEnumerable<ResponseMessage> Messages { get; set; }
    }
}