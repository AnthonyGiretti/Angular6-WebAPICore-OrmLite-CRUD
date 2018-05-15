namespace Nexus.Cqrs.Commands.Exceptions
{
    using System;

    public class CommandException : SystemException
    {
        public CommandException(Guid commandId, string errorCode, string message)
            : this(commandId, errorCode, message, null)
        {
        }

        public CommandException(Guid commandId, string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.CommandId = commandId;
            this.ErrorCode = errorCode;
        }

        public Guid CommandId { get; }
        public string ErrorCode { get; }
    }
}