using Desk.Domain.Commands.Contracts;

namespace Desk.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool sucesso, string mensagem, object? dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object? Dados { get; set; }
    }
}