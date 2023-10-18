using System.ComponentModel.DataAnnotations;

namespace Company.Product.Adapters.Rest.Models
{
    public class ResponseMessage
    { 
       public enum TypeEnum
        {
            ERROR = 0,
            WARN = 1,
            INFO = 2     
        }

        [Required]
        public TypeEnum Type { get; set; }
        
        [Required]
        public string Message { get; set; }
    }
}