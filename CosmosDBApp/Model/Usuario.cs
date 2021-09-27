using System;

namespace CosmosDBApp.Model
{
    public class Usuario
    {
        public Guid id { get; set; }
        public string NomeUsuario { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }

    public class DadosPessoais
    {
        public string Telefone { get; set; }
        public string Estado { get; set; }
    }
}
