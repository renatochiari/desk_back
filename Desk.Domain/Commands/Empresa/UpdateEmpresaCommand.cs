using Desk.Domain.Commands.Empresa.Contracts;
using Desk.Domain.Commands.Contracts;
using Flunt.Notifications;

namespace Desk.Domain.Commands.Empresa
{
    public class UpdateEmpresaCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEmpresaCommand(Guid id, string documento, string nome, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Id = id;
            Documento = documento;
            Nome = nome;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;

            Validate();
        }

        public Guid Id { get; set; }
        public String Documento { get; set; }
        public String Nome { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cep { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }

        public void Validate()
        {
            AddNotifications(new UpdateEmpresaContract(this));
        }
    }
}