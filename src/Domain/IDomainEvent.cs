using System;
using MediatR;

namespace EKadry.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}