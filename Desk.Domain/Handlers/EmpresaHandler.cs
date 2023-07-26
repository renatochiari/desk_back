using System.Security.Claims;
using Desk.Domain.Commands;
using Desk.Domain.Commands.Contracts;
using Desk.Domain.Commands.Empresa;
using Desk.Domain.Entities;
using Desk.Domain.Handlers.Contracts;
using Desk.Domain.Repositories;

namespace Desk.Domain.Handlers
{
    public class EmpresaHandler : IHandler<CreateEmpresaCommand, IEnumerable<Claim>>,
                                  IHandler<UpdateEmpresaCommand, IEnumerable<Claim>>
    {
        private readonly IEmpresaRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EmpresaHandler(IEmpresaRepository repository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handle(CreateEmpresaCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Empresa inválida", command.Notifications);

            var empresa = new Empresa(
                command.Documento,
                command.Nome,
                command.Rua,
                command.Numero,
                command.Complemento,
                command.Bairro,
                command.Cep,
                command.Cidade,
                command.Estado,
                command.Email
            );

            _repository.Create(empresa);

            // Cria um usuário Administrador para a empresa
            var usuario = new Usuario(
                empresa.Documento,
                empresa.Nome,
                empresa.Rua,
                empresa.Numero,
                empresa.Complemento,
                empresa.Bairro,
                empresa.Cep,
                empresa.Cidade,
                empresa.Estado,
                empresa.Email,
                "123456",
                "adm",
                empresa.Id,
                null
            );

            _usuarioRepository.Create(usuario);

            return new GenericCommandResult(true, "Empresa criada com sucesso", empresa);
        }

        public ICommandResult Handle(UpdateEmpresaCommand command, IEnumerable<Claim> claims)
        {
            if (!command.IsValid)
                return new GenericCommandResult(false, "Empresa inválida", command.Notifications);

            var empresa = _repository.GetById(command.Id);

            if (empresa == null)
                return new GenericCommandResult(false, "Empresa não localizada", null);

            empresa.Documento = command.Documento;
            empresa.Nome = command.Nome;
            empresa.Rua = command.Rua;
            empresa.Numero = command.Numero;
            empresa.Complemento = command.Complemento;
            empresa.Bairro = command.Bairro;
            empresa.Cep = command.Cep;
            empresa.Cidade = command.Cidade;
            empresa.Estado = command.Estado;

            _repository.Update(empresa);

            return new GenericCommandResult(true, "Empresa alterada com sucesso!", empresa);
        }
    }
}