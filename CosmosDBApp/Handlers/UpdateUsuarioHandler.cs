using CosmosDBApp.Commands;
using CosmosDBApp.Common;
using CosmosDBApp.Common.Interface;
using MediatR;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDBApp.Handlers
{
    public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, Response>
    {
        protected Response _response;
        protected IIniciarBancoDados _iniciarBancoDados;

        public UpdateUsuarioHandler(IIniciarBancoDados iniciarBancoDados)
        {
            _response = new Response();
            _iniciarBancoDados = iniciarBancoDados;
        }

        public async Task<Response> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = _iniciarBancoDados.CriarBancoCosmosDB();

                Document doc = await client.UpsertDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri("DatabaseUsuarios", "Usuarios"),
                    request);

                _response.AddValue(doc.Id);
                return _response;
            }
            catch
            {
                throw;
            }
        }
    }
}
