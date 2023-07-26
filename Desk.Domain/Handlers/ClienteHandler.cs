using System.Security.Claims;
using Desk.Domain.Commands;
using Desk.Domain.Commands.Cliente;
using Desk.Domain.Commands.Contracts;
using Desk.Domain.Entities;
using Desk.Domain.Handlers.Contracts;
using Desk.Domain.Repositories;

namespace Desk.Domain.Handlers
{
    public class ClienteHandler : IHandler<CreateClienteCommand, IEnumerable<Claim>>,
                                  IHandler<UpdateClienteCommand, IEnumerable<Claim>>
    {
        private readonly IClienteRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ClienteHandler(IClienteRepository repository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handle(CreateClienteCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Cliente inválido", command.Notifications);

            var cliente = new Cliente(
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
                new Guid(claims.First(c => c.Type == "empresaId").Value)
            );

            _repository.Create(cliente);

            // Cria usuário para o cliente
            var usuario = new Usuario(
                cliente.Documento,
                cliente.Nome,
                cliente.Rua,
                cliente.Numero,
                cliente.Complemento,
                cliente.Bairro,
                cliente.Cep,
                cliente.Cidade,
                cliente.Estado,
                cliente.Email,
                "123456",
                "cli",
                cliente.EmpresaId,
                cliente.Id
            );

            _usuarioRepository.Create(usuario);

            return new GenericCommandResult(true, "Cliente criado com sucesso", cliente);
        }

        public ICommandResult Handle(UpdateClienteCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Cliente inválido", command.Notifications);

            var cliente = _repository.GetById(new Guid(claims.First(c => c.Type == "empresaId").Value), command.Id);

            if (cliente == null)
                return new GenericCommandResult(false, "Cliente não localizado", null);

            cliente.Documento = command.Documento;
            cliente.Nome = command.Nome;
            cliente.Rua = command.Rua;
            cliente.Numero = command.Numero;
            cliente.Complemento = command.Complemento;
            cliente.Bairro = command.Bairro;
            cliente.Cep = command.Cep;
            cliente.Cidade = command.Cidade;
            cliente.Estado = command.Estado;

            _repository.Update(cliente);

            return new GenericCommandResult(true, "Cliente alterado com sucesso!", cliente);
        }
    }
}