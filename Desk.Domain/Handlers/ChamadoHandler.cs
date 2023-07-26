using System.Security.Claims;
using Desk.Domain.Commands;
using Desk.Domain.Commands.Chamado;
using Desk.Domain.Commands.Contracts;
using Desk.Domain.Entities;
using Desk.Domain.Handlers.Contracts;
using Desk.Domain.Repositories;

namespace Desk.Domain.Handlers
{
    public class ChamadoHandler : IHandler<CreateChamadoCommand, IEnumerable<Claim>>,
                                  IHandler<UpdateChamadoCommand, IEnumerable<Claim>>
    {
        private readonly IChamadoRepository _repository;

        public ChamadoHandler(IChamadoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateChamadoCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Chamado inválido", command.Notifications);

            var clienteId = claims.First(c => c.Type == "clienteId").Value != "" ? new Guid(claims.First(c => c.Type == "clienteId").Value) : new Guid("00000000-0000-0000-0000-000000000000");
            var usuarioId = new Guid(claims.First(c => c.Type == "usuarioId").Value);
            var empresaId = new Guid(claims.First(c => c.Type == "empresaId").Value);

            // se o usuario for "cliente" não permite abrir chamado para outro cliente
            if (claims.First(c => c.Type == ClaimTypes.Role).Value.Contains("cli") && clienteId != command.ClienteId)
                return new GenericCommandResult(false, "Cliente informado incorreto", null);

            var chamado = new Chamado(
                command.Texto,
                DateTime.Now,
                usuarioId,
                empresaId,
                command.ClienteId
            );

            _repository.Create(chamado);

            return new GenericCommandResult(true, "Chamado criado com sucesso", chamado);
        }

        public ICommandResult Handle(UpdateChamadoCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Chamado inválido", command.Notifications);

            var chamado = _repository.GetById(new Guid(claims.First(c => c.Type == "empresaId").Value), command.Id);

            if (chamado == null)
                return new GenericCommandResult(false, "Chamado não localizado", null);

            chamado.Texto = command.Texto;

            _repository.Update(chamado);

            return new GenericCommandResult(true, "Chamado alterada com sucesso", chamado);
        }
    }
}