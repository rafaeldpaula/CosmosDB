using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBApp.Common.Interface
{
    public interface IIniciarBancoDados
    {
        IDocumentClient CriarBancoCosmosDB();
    }
}
