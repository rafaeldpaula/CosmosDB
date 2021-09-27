using CosmosDBApp.Common;
using MediatR;

namespace CosmosDBApp.Commands
{
    public class GetUsuarioCommand : IRequest<Response>
    {
        public string Id { get; set; }
        public string NomeUsuario { get; set; }
        public Endereco Endereco { get; set; }
    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
