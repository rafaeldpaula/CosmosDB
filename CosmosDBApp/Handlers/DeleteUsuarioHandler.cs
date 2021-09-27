using CosmosDBApp.Commands;
using CosmosDBApp.Common;
using CosmosDBApp.Common.Interface;
using MediatR;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDBApp.Handlers
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, Response>
    {
        protected Response _response;
        protected IIniciarBancoDados _iniciarBancoDados;

        public DeleteUsuarioHandler(IIniciarBancoDados iniciarBancoDados)
        {
            _response = new Response();
            _iniciarBancoDados = iniciarBancoDados;
        }

        public async Task<Response> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = _iniciarBancoDados.CriarBancoCosmosDB();

                var doc = await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("DatabaseUsuarios", "Usuarios", request.Id));

                _response.AddValue(new
                {
                    Status = "Removido com sucesso!"
                });

                return _response;
            }
            catch
            {
                throw;
            }
        }
    }
}
