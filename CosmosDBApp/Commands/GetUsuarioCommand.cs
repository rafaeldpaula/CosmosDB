using CosmosDBApp.Common;
using CosmosDBApp.Model;
using MediatR;

namespace CosmosDBApp.Commands
{
    public class GetUsuarioCommand : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
