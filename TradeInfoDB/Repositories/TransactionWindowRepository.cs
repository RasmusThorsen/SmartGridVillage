using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using TradeInfoDB.Models;

namespace TradeInfoDB.Repositories
{
    public class TransactionWindowRepository
    {
        private DocumentClient _client;
        private const string _endPointUrl = "https://localhost:8081";
        private const string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private const string _databaseName = "TradeInfoDB";
        private const string _collectionName = "TransactionWindowCollection";

        public TransactionWindowRepository()
        {
            Connect();
        }

        public IEnumerable<TransactionWindow> GetAll()
        {
            IEnumerable<TransactionWindow> query =
                _client.CreateDocumentQuery<TransactionWindow>(
                    UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName)).ToList();

            return query;
        }

        public TransactionWindow Get(string id)
        {
            IEnumerable<TransactionWindow> query = _client
                .CreateDocumentQuery<TransactionWindow>(
                    UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName))
                .Where(t => t.TransactionWindowId == id).ToList();

            // Can return the first element in the query list, cause each ID must be unique.
            return query.ToList()[0];
        }

        public void Insert(TransactionWindow transactionWindow)
        {
            try
            {
                _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName), transactionWindow).Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Cant insert new person: " + e.Message);
            }
        }

        public void ChangeDocument(string id, TransactionWindow newTransactionWindow)
        {
            try
            {
                _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_databaseName, _collectionName, id), newTransactionWindow).Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Cant find document with ID: " + e.Message);
            }
            
        }

        public void Delete(string id)
        {
            try
            {
                _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_databaseName, _collectionName, id)).Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Cant delete document with ID: " + e.Message);
            }
        }

        public void Connect()
        {
            try
            {
                this._client = new DocumentClient(new Uri(_endPointUrl), _primaryKey);
                this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseName }).Wait();
                this._client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_databaseName),
                    new DocumentCollection { Id = _collectionName }).Wait();
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