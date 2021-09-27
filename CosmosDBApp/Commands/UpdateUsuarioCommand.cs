using CosmosDBApp.Common;
using CosmosDBApp.Model;
using MediatR;

namespace CosmosDBApp.Commands
{
    public class UpdateUsuarioCommand : Usuario, IRequest<Response>
    {
    }
}
