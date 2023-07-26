using System.Security.Claims;
using Desk.Domain.Commands;
using Desk.Domain.Commands.Empresa;
using Desk.Domain.Entities;
using Desk.Domain.Handlers;
using Desk.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desk.Api.Controllers
{
    [ApiController]
    [Route("v1/empresas")]
    [AllowAnonymous]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Empresa> GetAll([FromServices] IEmpresaRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Empresa? GetById(Guid id, [FromServices] IEmpresaRepository repository)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create([FromBody] CreateEmpresaCommand command, [FromServices] EmpresaHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, new List<Claim>());
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Update([FromBody] UpdateEmpresaCommand command, [FromServices] EmpresaHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command, new List<Claim>());
        }
    }
}