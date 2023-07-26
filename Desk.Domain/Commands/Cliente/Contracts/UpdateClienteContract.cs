using Flunt.Validations;

namespace Desk.Domain.Commands.Cliente.Contracts
{
    public class UpdateClienteContract : Contract<UpdateClienteCommand>
    {
        public UpdateClienteContract(UpdateClienteCommand command)
        {
            Requires()
            .IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id do cliente não informado")
            .IsTrue(command.Documento.Length == 11 || command.Documento.Length == 14, "Documento", "Documento inválido")
            .IsGreaterOrEqualsThan(command.Nome, 3, "Nome", "Nome deve ter pelo menos 3 caracteres")
            .IsEmail(command.Email, "Email", "E-mail inválido");
        }
    }
}