using Desk.Domain.Commands.Chamado.Contracts;
using Desk.Domain.Commands.Contracts;
using Flunt.Notifications;

namespace Desk.Domain.Commands.Chamado
{
    public class UpdateChamadoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateChamadoCommand(Guid id, Guid empresaId, string texto)
        {
            Id = id;
            Texto = texto;

            Validate();
        }

        public Guid Id { get; set; }
        public String Texto { get; set; }

        public void Validate()
        {
            AddNotifications(new UpdateChamadoContract(this));
        }
    }
}