namespace Desk.Domain.Entities
{
    public class Empresa : Pessoa
    {
        public Empresa(string documento, string nome, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado, string email) : base(documento, nome, rua, numero, complemento, bairro, cep, cidade, estado, email)
        { }
    }
}