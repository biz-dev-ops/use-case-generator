namespace Company.Product.Adapters.Rest.Models;
public class ResponseMessage
{
    public enum TypeEnum
    {
        ERROR,
        WARN,
        INFO
    }

    [Required]
    public TypeEnum Type { get; set; }

    [Required]
    public string Message { get; set; }
}