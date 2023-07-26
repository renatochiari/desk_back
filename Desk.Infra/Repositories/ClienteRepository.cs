using Desk.Domain.Entities;
using Desk.Domain.Queries;
using Desk.Domain.Repositories;
using Desk.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Desk.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            if (_context.Clientes == null)
                return;

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll(Guid empresaId)
        {
            if (_context.Clientes == null)
                return new List<Cliente>();

            return _context.Clientes.AsNoTracking().Where(ClienteQueries.GetAll(empresaId)).OrderBy(x => x.Nome);
        }

        public Cliente? GetById(Guid empresaId, Guid id)
        {
            if (_context.Clientes == null)
                return null;

            return _context.Clientes.FirstOrDefault(ClienteQueries.GetById(empresaId, id));
        }

        public IEnumerable<Cliente> GetByNome(Guid empresaId, string nome)
        {
            if (_context.Clientes == null)
                return new List<Cliente>();

            return _context.Clientes.AsNoTracking().Where(ClienteQueries.GetByNome(empresaId, nome)).OrderBy(x => x.Nome);
        }

        public void Update(Cliente cliente)
        {
            if (_context.Clientes == null)
                return;

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}