using Desk.Domain.Commands.Contracts;
using Desk.Domain.Commands.Usuario.Contracts;
using Flunt.Notifications;

namespace Desk.Domain.Commands.Usuario
{
    public class LoginUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public LoginUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;

            Validate();
        }

        public String Email { get; set; }
        public String Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new LoginUsuarioContract(this));
        }
    }
}