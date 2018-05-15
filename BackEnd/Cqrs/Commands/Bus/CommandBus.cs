namespace Cqrs.Commands.Bus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Cqrs.Commands.Exceptions;
    using Cqrs.Commands.Handlers;

    public class CommandBus : ICommandBus
    {
        private readonly IDictionary<Type, ICommandHandler> _handlersByCommandType;

        public CommandBus(IEnumerable<ICommandHandler> commandHandlers)
        {
            this._handlersByCommandType = commandHandlers.ToDictionary(x => x.HandledType, x => x);
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (!this._handlersByCommandType.TryGetValue(command.GetType(), out var commandHandler))
            {
                throw new NoCommandHandlersException(command);
            }

            await commandHandler.Handle(command);
        }
    }
}