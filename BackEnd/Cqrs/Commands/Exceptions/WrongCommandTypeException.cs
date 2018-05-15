namespace Cqrs.Commands.Exceptions
{
    public class WrongCommandTypeException : CommandException
    {
        public WrongCommandTypeException(ICommand command)
            : base(command.CommandId, "wrong-command-type", $"The command handler cannot handle commands of type {command.GetType()}.")
        {
        }
    }
}