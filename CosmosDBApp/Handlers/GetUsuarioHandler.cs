using CosmosDBApp.Commands;
using CosmosDBApp.Common;
using CosmosDBApp.Common.Interface;
using MediatR;
using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDBApp.Handlers
{
    public class GetUsuarioHandler : IRequestHandler<GetUsuarioCommand, Response>
    {
        protected Response _response;
        protected IIniciarBancoDados _iniciarBancoDados;

        public GetUsuarioHandler(IIniciarBancoDados iniciarBancoDados)
        {
            _response = new Response();
            _iniciarBancoDados = iniciarBancoDados;
        }

        public async Task<Response> Handle(GetUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = _iniciarBancoDados.CriarBancoCosmosDB();

                var docs = client.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri("DatabaseUsuarios", "Usuarios"),
                    $"SELECT c.id, c.NomeUsuario, c.DadosPessoais.Telefone as Telefone, c.DadosPessoais.Estado as Estado FROM c WHERE c.id = '{request.Id}'").ToList();

                foreach (var doc in docs)
                {
                    _response.AddValue(new 
                    {
                        id = doc.id,
                        NomeUsuario = doc.NomeUsuario,
                        Telefone = doc.Telefone,
                        Estado = doc.Estado
                    });
                }
                                
                return _response;
            }
            catch
            {
                throw;
            }
        }
    }
}
