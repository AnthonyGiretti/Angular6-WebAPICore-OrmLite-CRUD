namespace Cqrs.Commands.Bus
{
    using System.Threading.Tasks;

    public interface ICommandBus
    {
        Task Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}