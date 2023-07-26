namespace Desk.Domain.Entities
{
    public abstract class Pessoa : Entity
    {
        public Pessoa(string documento, string nome, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado, string email)
        {
            Documento = documento;
            Nome = nome;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            Email = email;
        }

        public String Documento { get; set; }
        public String Nome { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cep { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String Email { get; set; }
    }
}