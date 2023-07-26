using Flunt.Validations;

namespace Desk.Domain.Commands.Empresa.Contracts
{
    public class UpdateEmpresaContract : Contract<UpdateEmpresaCommand>
    {
        public UpdateEmpresaContract(UpdateEmpresaCommand command)
        {
            Requires()
            .IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id da empresa não informado")
            .IsTrue(command.Documento.Length == 11 || command.Documento.Length == 14, "Documento", "Documento inválido")
            .IsGreaterOrEqualsThan(command.Nome, 3, "Nome", "Nome deve ter pelo menos 3 caracteres");
        }
    }
}