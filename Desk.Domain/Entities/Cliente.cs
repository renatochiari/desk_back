namespace Desk.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Cliente(string documento, string nome, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado, string email, Guid empresaId) : base(documento, nome, rua, numero, complemento, bairro, cep, cidade, estado, email)
        {
            EmpresaId = empresaId;
        }

        public Guid EmpresaId { get; private set; }
        public Empresa? Empresa { get; private set; }

        public void UpdateEmpresa(Empresa empresa)
        {
            Empresa = empresa;
            EmpresaId = empresa.Id;
        }
    }
}