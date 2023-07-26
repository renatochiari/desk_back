using Desk.Domain.Commands;
using Desk.Domain.Commands.Cliente;
using Desk.Domain.Entities;
using Desk.Domain.Handlers;
using Desk.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desk.Api.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "adm,sup")]
        public IEnumerable<Cliente> GetAll([FromServices] IClienteRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetAll(new Guid(empresaId));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public Cliente? GetById(Guid id, [FromServices] IClienteRepository repository)
        {
            if (User.IsInRole("cli") && User.Claims.First(c => c.Type == "clienteId").Value != id.ToString())
                return null;

            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetById(new Guid(empresaId), id);
        }

        [HttpGet]
        [Route("nome/{nome}")]
        [Authorize(Roles = "adm,sup")]
        public IEnumerable<Cliente> GetByNome(string nome, [FromServices] IClienteRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetByNome(new Guid(empresaId), nome);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "adm")]
        public GenericCommandResult Create([FromBody] CreateClienteCommand command, [FromServices] ClienteHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, User.Claims);
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "adm")]
        public GenericCommandResult Update([FromBody] UpdateClienteCommand command, [FromServices] ClienteHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, User.Claims);
        }
    }
}