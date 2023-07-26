using Flunt.Validations;

namespace Desk.Domain.Commands.Usuario.Contracts
{
    public class LoginUsuarioContract : Contract<LoginUsuarioCommand>
    {
        public LoginUsuarioContract(LoginUsuarioCommand command)
        {
            Requires()
            .IsEmail(command.Email, "Email", "E-mail inválido")
            .IsNotNullOrWhiteSpace(command.Senha, "Senha", "Senha não informada");
        }
    }
}