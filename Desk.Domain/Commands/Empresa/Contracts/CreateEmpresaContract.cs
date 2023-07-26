using Flunt.Validations;

namespace Desk.Domain.Commands.Empresa.Contracts
{
    public class CreateEmpresaContract : Contract<CreateEmpresaCommand>
    {
        public CreateEmpresaContract(CreateEmpresaCommand command)
        {
            Requires()
            .IsTrue(command.Documento.Length == 11 || command.Documento.Length == 14, "Documento", "Documento inválido")
            .IsGreaterOrEqualsThan(command.Nome, 3, "Nome", "Nome deve ter pelo menos 3 caracteres")
            .IsEmail(command.Email, "Email", "E-mail inválido");
        }
    }
}