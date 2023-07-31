using System.Net;
using System.Security.Claims;
using Desk.Domain.Commands;
using Desk.Domain.Commands.Usuario;
using Desk.Domain.Entities;
using Desk.Domain.Handlers;
using Desk.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desk.Api.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "adm")]
        public IEnumerable<Usuario> GetAll([FromServices] IUsuarioRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetAll(new Guid(empresaId));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public Usuario? GetById(Guid id, [FromServices] IUsuarioRepository repository)
        {
            if (!User.IsInRole("adm") && User.Claims.First(c => c.Type == "usuarioId").Value != id.ToString())
                return null;

            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetById(new Guid(empresaId), id);
        }

        [HttpGet]
        [Route("nome/{nome}")]
        [Authorize(Roles = "adm")]
        public IEnumerable<Usuario> GetByNome(string nome, [FromServices] IUsuarioRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetByNome(new Guid(empresaId), nome);
        }

        [HttpGet]
        [Route("cliente/{id}")]
        [Authorize(Roles = "adm,sup")]
        public IEnumerable<Usuario> GetByCliente(Guid id, [FromServices] IUsuarioRepository repository)
        {
            var empresaId = User.Claims.First(c => c.Type == "empresaId").Value;
            return repository.GetByCliente(new Guid(empresaId), id);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "adm")]
        public GenericCommandResult Create([FromBody] CreateUsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, User.Claims);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public GenericCommandResult Login([FromBody] LoginUsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, new List<Claim>());
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "adm")]
        public GenericCommandResult Update([FromBody] UpdateUsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, User.Claims);
        }
    }
}