namespace Nexus.Cqrs.Commands.Exceptions
{
    public class NoCommandHandlersException : CommandException
    {
        public NoCommandHandlersException(ICommand command)
            : base(command.CommandId, "no-command-handlers", $"The command of type {command.GetType()} has no associated handler.")
        {
        }
    }
}