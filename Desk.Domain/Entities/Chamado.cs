namespace Desk.Domain.Entities
{
    public class Chamado : Entity
    {
        public Chamado(string texto, DateTime dataHora, Guid? usuarioId, Guid? empresaId, Guid? clienteId)
        {
            Texto = texto;
            DataHora = dataHora;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
            ClienteId = clienteId;
        }

        public String Texto { get; set; }
        public DateTime DataHora { get; set; }
        public Guid? UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public Guid? EmpresaId { get; private set; }
        public Empresa? Empresa { get; private set; }
        public Guid? ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }

        public void UpdateUsuario(Usuario usuario)
        {
            Usuario = usuario;
            UsuarioId = usuario.Id;
        }

        public void UpdateEmpresa(Empresa empresa)
        {
            Empresa = empresa;
            EmpresaId = empresa.Id;
        }

        public void UpdateCliente(Cliente cliente)
        {
            Cliente = cliente;
            ClienteId = cliente.Id;
        }
    }
}