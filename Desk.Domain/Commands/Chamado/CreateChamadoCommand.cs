using Desk.Domain.Commands.Chamado.Contracts;
using Desk.Domain.Commands.Contracts;
using Flunt.Notifications;

namespace Desk.Domain.Commands.Chamado
{
    public class CreateChamadoCommand : Notifiable<Notification>, ICommand
    {
        public CreateChamadoCommand(string texto, Guid clienteId)
        {
            Texto = texto;
            ClienteId = clienteId;

            Validate();
        }

        public String Texto { get; set; }
        public Guid ClienteId { get; set; }

        public void Validate()
        {
            AddNotifications(new CreateChamadoContract(this));
        }
    }
}