using System.Linq.Expressions;
using Desk.Domain.Entities;

namespace Desk.Domain.Queries
{
    public static class ChamadoQueries
    {
        public static Expression<Func<Chamado, bool>> GetById(Guid empresaId, Guid id)
        {
            return x => x.EmpresaId == empresaId && x.Id == id;
        }

        public static Expression<Func<Chamado, bool>> GetById(Guid empresaId, Guid clienteId, Guid id)
        {
            return x => x.EmpresaId == empresaId && x.ClienteId == clienteId && x.Id == id;
        }

        public static Expression<Func<Chamado, bool>> GetAll(Guid empresaId)
        {
            return x => x.EmpresaId == empresaId;
        }

        public static Expression<Func<Chamado, bool>> GetByUsuario(Guid empresaId, Guid usuarioId)
        {
            return x => x.EmpresaId == empresaId && x.UsuarioId == usuarioId;
        }

        public static Expression<Func<Chamado, bool>> GetByCliente(Guid empresaId, Guid clienteId)
        {
            return x => x.EmpresaId == empresaId && x.ClienteId == clienteId;
        }
    }
}