using System.Linq.Expressions;
using Desk.Domain.Entities;

namespace Desk.Domain.Queries
{
    public static class EmpresaQueries
    {
        public static Expression<Func<Empresa, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}