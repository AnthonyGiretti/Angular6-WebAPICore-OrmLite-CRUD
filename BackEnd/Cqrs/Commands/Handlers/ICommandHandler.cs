namespace Nexus.Cqrs.Commands.Handlers
{
    using System;
    using System.Threading.Tasks;

    public interface ICommandHandler
    {
        Type HandledType { get; }

        Task Handle(ICommand command);
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}