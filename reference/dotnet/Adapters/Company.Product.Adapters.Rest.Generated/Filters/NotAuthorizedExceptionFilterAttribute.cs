namespace Company.Product.Adapters.Rest.Attributes
{
    public class NotAuthorizedExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception.GetType().Equals(typeof(NotAuthorizedException)))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}