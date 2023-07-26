using Desk.Domain.Entities;
using Desk.Domain.Queries;
using Desk.Domain.Repositories;
using Desk.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Desk.Infra.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public readonly DataContext _context;

        public EmpresaRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Empresa empresa)
        {
            if (_context.Empresas == null)
                return;

            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        public IEnumerable<Empresa> GetAll()
        {
            if (_context.Empresas == null)
                return new List<Empresa>();

            return _context.Empresas.AsNoTracking().OrderBy(x => x.Nome);
        }

        public Empresa? GetById(Guid id)
        {
            if (_context.Empresas == null)
                return null;

            return _context.Empresas.FirstOrDefault(EmpresaQueries.GetById(id));
        }

        public void Update(Empresa empresa)
        {
            if (_context.Empresas == null)
                return;

            _context.Entry(empresa).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}