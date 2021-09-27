using CosmosDBApp.Commands;
using CosmosDBApp.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDBApp.Handlers
{
    public class GetUsuarioHandler : IRequestHandler<GetUsuarioCommand, Response>
    {
        protected Response _response;

        public GetUsuarioHandler()
        {
            _response = new Response();
        }

        public async Task<Response> Handle(GetUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _response.AddValue(new
                {
                    Flag = "Hello World!"
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
