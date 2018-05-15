namespace Cqrs.Commands
{
    using System;

    public interface ICommand
    {
        Guid CommandId { get; }
    }
}