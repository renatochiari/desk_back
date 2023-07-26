namespace Desk.Domain.Entities
{
    public class Usuario : Pessoa
    {
        public Usuario(string documento, string nome, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado, string email, string senha, string regra, Guid empresaId, Guid? clienteId) : base(documento, nome, rua, numero, complemento, bairro, cep, cidade, estado, email)
        {
            Senha = senha;
            Regra = regra;
            EmpresaId = empresaId;
            ClienteId = clienteId;
        }

        public String Senha { get; set; }
        public String Regra { get; set; }
        public Guid EmpresaId { get; private set; }
        public Empresa? Empresa { get; private set; }
        public Guid? ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }

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

        public void RemoverSenha()
        {
            Senha = "";
        }
    }
}