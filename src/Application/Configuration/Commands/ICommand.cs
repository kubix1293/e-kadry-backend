﻿using System;
using EKadry.Domain.Operators;
using MediatR;

namespace EKadry.Application.Configuration.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface ICommand: IRequest
    {
        Guid Id { get; }
    }
}