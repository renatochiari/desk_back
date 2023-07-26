using System.Linq.Expressions;
using Desk.Domain.Entities;

namespace Desk.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static Expression<Func<Usuario, bool>> GetById(Guid empresaId, Guid id)
        {
            return x => x.EmpresaId == empresaId && x.Id == id;
        }

        public static Expression<Func<Usuario, bool>> GetAll(Guid empresaId)
        {
            return x => x.EmpresaId == empresaId;
        }

        public static Expression<Func<Usuario, bool>> GetByCliente(Guid empresaId, Guid clienteId)
        {
            return x => x.EmpresaId == empresaId && x.ClienteId == clienteId;
        }

        public static Expression<Func<Usuario, bool>> GetByEmail(String email)
        {
            return x => x.Email == email;
        }
    }
}