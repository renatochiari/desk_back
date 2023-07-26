using Desk.Domain.Entities;
using Desk.Domain.Queries;
using Desk.Domain.Repositories;
using Desk.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Desk.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Usuario usuario)
        {
            if (_context.Usuarios == null)
                return;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll(Guid empresaId)
        {
            if (_context.Usuarios == null)
                return new List<Usuario>();

            return _context.Usuarios.AsNoTracking().Where(UsuarioQueries.GetAll(empresaId)).OrderBy(x => x.Nome);
        }

        public IEnumerable<Usuario> GetByCliente(Guid empresaId, Guid clienteId)
        {
            if (_context.Usuarios == null)
                return new List<Usuario>();

            return _context.Usuarios.AsNoTracking().Where(UsuarioQueries.GetByCliente(empresaId, clienteId)).OrderBy(x => x.Nome);
        }

        public Usuario? GetById(Guid empresaId, Guid id)
        {
            if (_context.Usuarios == null)
                return null;

            return _context.Usuarios.FirstOrDefault(UsuarioQueries.GetById(empresaId, id));
        }

        public Usuario? GetByEmail(string email)
        {
            if (_context.Usuarios == null)
                return null;

            return _context.Usuarios.FirstOrDefault(UsuarioQueries.GetByEmail(email));
        }

        public void Update(Usuario usuario)
        {
            if (_context.Usuarios == null)
                return;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}