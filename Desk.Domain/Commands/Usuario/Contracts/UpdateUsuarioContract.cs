using Flunt.Validations;

namespace Desk.Domain.Commands.Usuario.Contracts
{
    public class UpdateUsuarioContract : Contract<UpdateUsuarioCommand>
    {
        public UpdateUsuarioContract(UpdateUsuarioCommand command)
        {
            Requires()
            .IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id do usuário não informado")
            .IsTrue(command.Documento.Length == 11 || command.Documento.Length == 14, "Documento", "Documento inválido")
            .IsGreaterOrEqualsThan(command.Nome, 3, "Nome", "Nome deve ter pelo menos 3 caracteres");
        }
    }
}