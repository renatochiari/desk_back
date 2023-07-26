using Flunt.Validations;

namespace Desk.Domain.Commands.Cliente.Contracts
{
    public class CreateClienteContract : Contract<CreateClienteCommand>
    {
        public CreateClienteContract(CreateClienteCommand command)
        {
            Requires()
            .IsTrue(command.Documento.Length == 11 || command.Documento.Length == 14, "Documento", "Documento inválido")
            .IsGreaterOrEqualsThan(command.Nome, 3, "Nome", "Nome deve ter pelo menos 3 caracteres")
            .IsEmail(command.Email, "Email", "E-mail inválido");
        }
    }
}