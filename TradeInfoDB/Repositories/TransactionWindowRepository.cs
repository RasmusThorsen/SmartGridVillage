using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using TradeInfoDB.Models;

namespace TradeInfoDB.Repositories
{
    public class TransactionWindowRepository
    {
        private DocumentClient _client;
        private const string _endPointURL = "https://localhost:8081";
        private const string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private const string databaseName = "TradeInfoDB";
        private const string collectionName = "TransactionWindowCollection";

        public TransactionWindowRepository()
        {
            var connectTask = Connect();
            Task.WaitAll(connectTask);
        }

        public IEnumerable<TransactionWindow> GetAll()
        {
            throw new NotImplementedException();
        }







        public async Task Connect()
        {
            try
            {
                _client = new DocumentClient(new Uri(_endPointURL), _primaryKey);
                _client.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName }).Wait();
                await _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection {Id = collectionName});
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Debug.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Debug.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Debug.WriteLine("Connection == true");
            }
        }

        
    }
}