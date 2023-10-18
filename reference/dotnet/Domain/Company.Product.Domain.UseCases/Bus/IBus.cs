using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Bus
{
    public interface IBus
    {
        Task Handle(ICommand command, CancellationToken cancellationToken = default);
        Task<TResponse> Handle<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}