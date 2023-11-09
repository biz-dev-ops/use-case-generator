namespace Company.Product.Adapters.Rest.Attributes
{
    public class NotAuthenticatedExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception.GetType().Equals(typeof(NotAuthenticatedException)))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}