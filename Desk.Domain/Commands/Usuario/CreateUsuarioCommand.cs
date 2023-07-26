using Desk.Domain.Commands.Usuario.Contracts;
using Desk.Domain.Commands.Contracts;
using Flunt.Notifications;

namespace Desk.Domain.Commands.Usuario
{
    public class CreateUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public CreateUsuarioCommand(string regra, Guid? clienteId, string documento, string nome, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado, string email)
        {
            Regra = regra;
            ClienteId = clienteId;
            Documento = documento;
            Nome = nome;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            Email = email;

            Validate();
        }

        public String Regra { get; set; }
        public Guid? ClienteId { get; set; }
        public String Documento { get; set; }
        public String Nome { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cep { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String Email { get; set; }

        public void Validate()
        {
            AddNotifications(new CreateUsuarioContract(this));
        }
    }
}