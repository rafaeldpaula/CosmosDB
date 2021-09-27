using CosmosDBApp.Common;
using CosmosDBApp.Model;
using MediatR;

namespace CosmosDBApp.Commands
{
    public class DeleteUsuarioCommand : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
