namespace Cqrs.Commands
{
    using System;

    public abstract class BaseCommand : ICommand
    {
        public Guid CommandId { get; protected set; } = Guid.NewGuid();
    }
}