using Microsoft.AspNetCore.Mvc.Filters;

namespace Company.Product.Adapters.Rest.Attributes
{
    public class NotFoundFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var exceptionTypes = new Type[] {
                typeof(InvalidOperationException),
                typeof(KeyNotFoundException)
            };

            if (exceptionTypes.Contains(context.Exception.GetType()))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}