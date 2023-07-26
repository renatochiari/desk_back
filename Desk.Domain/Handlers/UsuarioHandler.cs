using System.Security.Claims;
using Desk.Domain.Commands;
using Desk.Domain.Commands.Contracts;
using Desk.Domain.Commands.Usuario;
using Desk.Domain.Entities;
using Desk.Domain.Handlers.Contracts;
using Desk.Domain.Repositories;
using Desk.Domain.Services;

namespace Desk.Domain.Handlers
{
    public class UsuarioHandler : IHandler<CreateUsuarioCommand, IEnumerable<Claim>>,
                                  IHandler<UpdateUsuarioCommand, IEnumerable<Claim>>,
                                  IHandler<LoginUsuarioCommand, IEnumerable<Claim>>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUsuarioCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            var usuario = new Usuario(
                command.Documento,
                command.Nome,
                command.Rua,
                command.Numero,
                command.Complemento,
                command.Bairro,
                command.Cep,
                command.Cidade,
                command.Estado,
                command.Email,
                "123456",
                command.Regra,
                new Guid(claims.First(c => c.Type == "empresaId").Value),
                command.ClienteId
            );

            _repository.Create(usuario);

            return new GenericCommandResult(true, "Usuário criado com sucesso", usuario);
        }

        public ICommandResult Handle(UpdateUsuarioCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            var empresaId = new Guid(claims.First(c => c.Type == "empresaId").Value);
            var usuario = _repository.GetById(empresaId, command.Id);

            if (usuario == null)
                return new GenericCommandResult(false, "Usuário não localizado", null);

            usuario.Documento = command.Documento;
            usuario.Nome = command.Nome;
            usuario.Rua = command.Rua;
            usuario.Numero = command.Numero;
            usuario.Complemento = command.Complemento;
            usuario.Bairro = command.Bairro;
            usuario.Cep = command.Cep;
            usuario.Cidade = command.Cidade;
            usuario.Estado = command.Estado;

            _repository.Update(usuario);
            usuario.RemoverSenha();

            return new GenericCommandResult(true, "Usuário alterado com sucesso!", usuario);
        }

        public ICommandResult Handle(LoginUsuarioCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Usuário ou senha incorretos", command.Notifications);

            var usuario = _repository.GetByEmail(command.Email);

            if (usuario == null || usuario.Senha != command.Senha)
                return new GenericCommandResult(false, "Usuário ou senha incorretos", null);

            usuario.RemoverSenha();
            var token = TokenService.GerarToken(usuario);

            return new GenericCommandResult(true, "Autenticação ralizada com sucesso", new { usuario = usuario, token = token });
        }
    }
}