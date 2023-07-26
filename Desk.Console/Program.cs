using System;
using Desk.Domain.Commands.Chamado;
using Desk.Domain.Commands.Empresa;
using Desk.Domain.Commands.Usuario;

class Program
{
    static void Main(string[] args)
    {
        var command = new UpdateUsuarioCommand(Guid.NewGuid(), "12345678901234", "Nome", "", "", "", "", "", "", "");

        if (command.IsValid)
            Console.WriteLine("OK");
        else
        {
            Console.WriteLine("Inválido");

            foreach (var item in command.Notifications)
            {
                Console.WriteLine(item.Message);
            }
        }
    }
}