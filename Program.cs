using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCosmosDBSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** COSMOS DB EXEMPLO ****");

            IDocumentClient client = new DocumentClient(
                new Uri("https://localhost:8081"), 
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

            // Cria o banco dinamicamente
            CreateDatabase(client).GetAwaiter().GetResult();

            // Cria o container
            CreateContainer(client).GetAwaiter().GetResult();

            // Adiciona o documento
            CreateDocument(client).GetAwaiter().GetResult();

            // Lendo os documentos
            ReadDocuments(client);

            Console.ReadLine();
        }

        async static Task CreateDatabase(IDocumentClient client)
        {
            Console.WriteLine("**** CRIANDO BANCO DE DADOS ****");

            try
            {
                Database db = await client.CreateDatabaseIfNotExistsAsync(
                    new Database { Id = "Database3" });

                Console.WriteLine("**** BANCO DE DADOS CRIADO COM SUCESSO ****");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Banco de dados não foi criado. Ex = {ex.Message}");
            }
        }

        async static Task CreateContainer(IDocumentClient client)
        {
            Console.WriteLine("**** CRIANDO O CONTAINER ****");

            try
            {
                DocumentCollection coll = await client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri("Database3"),
                    new DocumentCollection { Id = "Clientes" },
                    new RequestOptions { OfferThroughput = 10000 });

                Console.WriteLine("**** CONTAINER CRIADO COM SUCESSO ****");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Banco de dados não foi criado. Ex = {ex.Message}");
            }
        }

        async static Task CreateDocument(IDocumentClient client)
        {
            Console.WriteLine("**** CRIANDO O DOCUMENTO ****");

            try
            {
                Document doc1 = await client.CreateDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri("Database3", "Clientes"),
                    new { Nome = "Rafael", Telefone = "(19) 11111-1111" });

                Document doc2 = await client.CreateDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri("Database3", "Clientes"),
                    new { Nome = "Rodrigo", Telefone = "(19) 22222-2222" });

                Console.WriteLine("**** DOCUMENTO CRIADO COM SUCESSO ****");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Banco de dados não foi criado. Ex = {ex.Message}");
            }
        }

        static void ReadDocuments(IDocumentClient client)
        {
            Console.WriteLine("**** LENDO O DOCUMENTO ****");

            try
            {
                Console.WriteLine("**** EXEMPLO 1 ****");
                var docs = client.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri("Database3", "Clientes"),
                    "select * from c").ToList();

                foreach (var doc in docs)
                {
                    Console.WriteLine($"Nome:{doc.Nome}");
                    Console.WriteLine($"Telefone:{doc.Telefone}");
                }

                Console.WriteLine("**** EXEMPLO 2 ****");
                var docs2 = client.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri("Database3", "Clientes"),
                    "select c.Telefone from c").ToList();

                foreach (var doc in docs2)
                {
                    Console.WriteLine($"Telefone:{doc.Telefone}");
                }

                Console.WriteLine("**** EXEMPLO 3 ****");
                var docs3 = client.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri("Database3", "Clientes"),
                    "select c.Nome, c.Telefone from c where c.Nome = 'Rodrigo'").ToList();

                foreach (var doc in docs3)
                {
                    Console.WriteLine($"Nome:{doc.Nome}");
                    Console.WriteLine($"Telefone:{doc.Telefone}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Banco de dados não foi criado. Ex = {ex.Message}");
            }
        }
    }
}
