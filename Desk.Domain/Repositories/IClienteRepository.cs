using Desk.Domain.Entities;

namespace Desk.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        Cliente? GetById(Guid empresaId, Guid id);
        IEnumerable<Cliente> GetAll(Guid empresaId);
        IEnumerable<Cliente> GetByNome(Guid empresaId, string nome);
    }
}