using MediatR;

namespace EKadry.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}