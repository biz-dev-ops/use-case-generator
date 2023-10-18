using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Company.Product.Domain.UseCases.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Domain.UseCases.Mocks
{
    public class BusMock : IBus
    {
        private readonly IServiceProvider serviceProvider;
        private readonly MethodInfo handleCommandMethod;
        private readonly MethodInfo handleQueryMethod;

        public BusMock(IServiceProvider serviceProvider)
        {
            var type = GetType();
            this.handleCommandMethod = type.GetMethod(nameof(HandleCommand), BindingFlags.NonPublic | BindingFlags.Instance);
            this.handleQueryMethod = type.GetMethod(nameof(HandleQuery), BindingFlags.NonPublic | BindingFlags.Instance);
            this.serviceProvider = serviceProvider ??  throw new ArgumentNullException(nameof(serviceProvider));;
        }

        public Task Handle(ICommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return (Task)handleCommandMethod
                .MakeGenericMethod(command.GetType())
                .Invoke(this, new object[] { command, cancellationToken });
        }

        public Task<TResponse> Handle<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

            return (Task<TResponse>)handleQueryMethod
                .MakeGenericMethod(query.GetType(), typeof(TResponse))
                .Invoke(this, new object[] { query, cancellationToken });
        }


        private Task HandleCommand<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.Handle(command, cancellationToken);
        }

        private Task<TResponse> HandleQuery<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResponse>
        {
            var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
            return handler.Handle(query, cancellationToken);
        }
    }
}