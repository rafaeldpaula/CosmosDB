using CosmosDBApp.Common.Interface;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;

namespace CosmosDBApp.Common
{
    public class IniciarBancoDados : IIniciarBancoDados
    {
        public IDocumentClient CriarBancoCosmosDB()
        {
            try
            {
                IDocumentClient client = new DocumentClient(new Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

                Database db = client.CreateDatabaseIfNotExistsAsync(new Database { Id = "DatabaseUsuarios" }).GetAwaiter().GetResult();

                DocumentCollection coll =
                    client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("DatabaseUsuarios"),
                        new DocumentCollection { Id = "Usuarios" },
                        new RequestOptions { OfferThroughput = 10000 }).GetAwaiter().GetResult();

                return client;
            }
            catch
            {
                throw;
            }
        }
    }
}
