using Flunt.Validations;

namespace Desk.Domain.Commands.Chamado.Contracts
{
    public class CreateChamadoContract : Contract<CreateChamadoCommand>
    {
        public CreateChamadoContract(CreateChamadoCommand command)
        {
            Requires()
            .IsGreaterOrEqualsThan(command.Texto, 10, "Texto", "Texto deve ter pelo menos 10 caracteres")
            .IsNotNullOrEmpty(command.ClienteId.ToString(), "ClienteId", "Id do cliente não informado");
        }
    }
}