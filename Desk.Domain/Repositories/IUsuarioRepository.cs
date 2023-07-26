using Desk.Domain.Entities;

namespace Desk.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        Usuario? GetById(Guid empresaId, Guid id);
        Usuario? GetByEmail(String email);
        IEnumerable<Usuario> GetAll(Guid empresaId);
        IEnumerable<Usuario> GetByCliente(Guid empresaId, Guid clienteId);
    }
}