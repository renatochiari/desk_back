using Flunt.Validations;

namespace Desk.Domain.Commands.Usuario.Contracts
{
    public class CreateUsuarioContract : Contract<CreateUsuarioCommand>
    {
        public CreateUsuarioContract(CreateUsuarioCommand command)
        {
            Requires()
            .IsNotNullOrWhiteSpace(command.Regra, "Regra", "Regra do usuário não definida")
            .IsTrue(command.Documento.Length == 11 || command.Documento.Length == 14, "Documento", "Documento inválido")
            .IsGreaterOrEqualsThan(command.Nome, 3, "Nome", "Nome deve ter pelo menos 3 caracteres")
            .IsEmail(command.Email, "Email", "E-mail inválido");
        }
    }
}