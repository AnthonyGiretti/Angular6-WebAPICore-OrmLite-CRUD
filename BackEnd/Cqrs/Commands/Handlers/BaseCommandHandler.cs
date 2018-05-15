namespace Nexus.Cqrs.Commands.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Nexus.Cqrs.Commands.Exceptions;

    public abstract class BaseCommandHandler<TCommand>
        : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public Type HandledType => typeof(TCommand);

        public abstract Task Handle(TCommand command);

        public async Task Handle(ICommand command)
        {
            if (!(command is TCommand tCommand))
            {
                throw new WrongCommandTypeException(command);
            }

            await this.Handle(tCommand);
        }
    }
}