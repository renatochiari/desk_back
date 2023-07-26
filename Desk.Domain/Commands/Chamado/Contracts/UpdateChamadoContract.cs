using Flunt.Validations;

namespace Desk.Domain.Commands.Chamado.Contracts
{
    public class UpdateChamadoContract : Contract<UpdateChamadoCommand>
    {
        public UpdateChamadoContract(UpdateChamadoCommand command)
        {
            Requires()
            .IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id do chamado não informado")
            .IsGreaterOrEqualsThan(command.Texto, 10, "Texto", "Texto deve ter pelo menos 10 caracteres");
        }
    }
}