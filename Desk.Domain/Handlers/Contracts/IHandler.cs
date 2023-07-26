using System.Security.Claims;
using Desk.Domain.Commands.Contracts;

namespace Desk.Domain.Handlers.Contracts
{
    public interface IHandler<T, C> where T : ICommand where C : IEnumerable<Claim>
    {
        ICommandResult Handle(T command, C claims);
    }
}