using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Bus
{
    public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
    }
}