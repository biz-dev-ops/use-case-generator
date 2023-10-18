using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Domain.UseCases.Bus
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}