using Desk.Domain.Entities;
using Desk.Domain.Queries;
using Desk.Domain.Repositories;
using Desk.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Desk.Infra.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly DataContext _context;

        public ChamadoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Chamado chamado)
        {
            if (_context.Chamados == null)
                return;

            _context.Chamados.Add(chamado);
            _context.SaveChanges();
        }

        public IEnumerable<Chamado> GetAll(Guid empresaId)
        {
            if (_context.Chamados == null)
                return new List<Chamado>();

            return _context.Chamados.AsNoTracking().Where(ChamadoQueries.GetAll(empresaId)).OrderBy(x => x.DataHora);
        }

        public IEnumerable<Chamado> GetByCliente(Guid empresaId, Guid clienteId)
        {
            if (_context.Chamados == null)
                return new List<Chamado>();

            return _context.Chamados.AsNoTracking().Where(ChamadoQueries.GetByCliente(empresaId, clienteId)).OrderBy(x => x.DataHora);
        }

        public Chamado? GetById(Guid empresaId, Guid id)
        {
            if (_context.Chamados == null)
                return null;

            return _context.Chamados.FirstOrDefault(ChamadoQueries.GetById(empresaId, id));
        }

        public Chamado? GetById(Guid empresaId, Guid clienteId, Guid id)
        {
            if (_context.Chamados == null)
                return null;

            return _context.Chamados.FirstOrDefault(ChamadoQueries.GetById(empresaId, clienteId, id));
        }

        public IEnumerable<Chamado> GetByUsuario(Guid empresaId, Guid usuarioId)
        {
            if (_context.Chamados == null)
                return new List<Chamado>();

            return _context.Chamados.AsNoTracking().Where(ChamadoQueries.GetByUsuario(empresaId, usuarioId)).OrderBy(x => x.DataHora);
        }

        public void Update(Chamado chamado)
        {
            _context.Entry(chamado).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}