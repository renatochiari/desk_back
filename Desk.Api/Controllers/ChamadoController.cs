using Desk.Domain.Commands;
using Desk.Domain.Commands.Chamado;
using Desk.Domain.Entities;
using Desk.Domain.Handlers;
using Desk.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desk.Api.Controllers
{
    [ApiController]
    [Route("v1/chamados")]
    public class ChamadoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "adm,sup")]
        public IEnumerable<Chamado> GetAll([FromServices] IChamadoRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetAll(new Guid(empresaId));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public Chamado? GetById(Guid id, [FromServices] IChamadoRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;

            if (User.IsInRole("cli"))
            {
                var clienteId = User.Claims.First(c => c.Type == "clienteId").Value;
                return repository.GetById(new Guid(empresaId), new Guid(clienteId), id);
            }
            else
                return repository.GetById(new Guid(empresaId), id);
        }

        [HttpGet]
        [Route("usuario/{usuarioId}")]
        [Authorize]
        public IEnumerable<Chamado>? GetByUsuario(Guid usuarioId, [FromServices] IChamadoRepository repository)
        {
            if (User.IsInRole("cli") && usuarioId.ToString() != User.Claims.First(c => c.Type == "usuarioId").Value)
                return null;

            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetByUsuario(new Guid(empresaId), usuarioId);
        }

        [HttpGet]
        [Route("cliente/{clienteId}")]
        [Authorize]
        public IEnumerable<Chamado>? GetByCliente(Guid clienteId, [FromServices] IChamadoRepository repository)
        {
            if (User.IsInRole("cli") && clienteId.ToString() != User.Claims.First(c => c.Type == "clienteId").Value)
                return null;

            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetByCliente(new Guid(empresaId), clienteId);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public GenericCommandResult Create([FromBody] CreateChamadoCommand command, [FromServices] ChamadoHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, User.Claims);
        }

        [HttpPut]
        [Route("")]
        [Authorize]
        public GenericCommandResult Update([FromBody] UpdateChamadoCommand command, [FromServices] ChamadoHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, User.Claims);
        }
    }
}