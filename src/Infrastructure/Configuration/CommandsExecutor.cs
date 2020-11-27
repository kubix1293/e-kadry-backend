using System.Threading.Tasks;
using Autofac;
using EKadry.Application.Configuration.Commands;
using MediatR;

namespace EKadry.Infrastructure.Configuration
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}