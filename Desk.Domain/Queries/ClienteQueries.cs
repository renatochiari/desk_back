using System.Linq.Expressions;
using Desk.Domain.Entities;

namespace Desk.Domain.Queries
{
    public static class ClienteQueries
    {
        public static Expression<Func<Cliente, bool>> GetById(Guid empresaId, Guid id)
        {
            return x => x.EmpresaId == empresaId && x.Id == id;
        }

        public static Expression<Func<Cliente, bool>> GetAll(Guid empresaId)
        {
            return x => x.EmpresaId == empresaId;
        }

        public static Expression<Func<Cliente, bool>> GetByNome(Guid empresaId, string nome)
        {
            return x => x.Nome.Contains(nome);
        }
    }
}