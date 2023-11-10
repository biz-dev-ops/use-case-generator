namespace Company.Product.Adapters.Rest.Attributes
{
    public class NotFoundFilterExceptionAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception.GetType().Equals(typeof(NotFoundException)))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}