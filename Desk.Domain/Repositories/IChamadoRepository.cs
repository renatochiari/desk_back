using Desk.Domain.Entities;

namespace Desk.Domain.Repositories
{
    public interface IChamadoRepository
    {
        void Create(Chamado chamado);
        void Update(Chamado chamado);
        Chamado? GetById(Guid empresaId, Guid id);
        Chamado? GetById(Guid empresaId, Guid clienteId, Guid id);
        IEnumerable<Chamado> GetAll(Guid empresaId);
        IEnumerable<Chamado> GetByUsuario(Guid empresaId, Guid usuarioId);
        IEnumerable<Chamado> GetByCliente(Guid empresaId, Guid clienteId);
    }
}