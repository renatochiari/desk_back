using Desk.Domain.Entities;

namespace Desk.Domain.Repositories
{
    public interface IEmpresaRepository
    {
        void Create(Empresa empresa);
        void Update(Empresa empresa);
        Empresa? GetById(Guid id);
        IEnumerable<Empresa> GetAll();
    }
}