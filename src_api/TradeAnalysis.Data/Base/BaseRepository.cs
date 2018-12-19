using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using TradeAnalysis.Models;

namespace TradeAnalysis.Data.Base
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> Get(string id);
        Task<IList<T>> Get(Expression<Func<T, bool>> predicate);
        Task<T> Upsert(T model);
        Task Delete(string id);
    }

    public class DocumentRepository<T> : IRepository<T> where T : ModelBase
    {
        private readonly DocumentClientConfiguration _dbConfig;
        private readonly string _collectionId;


        public DocumentRepository(DocumentClientConfiguration dbConfig, string collectionId)
        {
            _dbConfig = dbConfig;
            _collectionId = collectionId;
        }

        public async Task<T> Get(string id)
        {
            using (var client = GetClient())
            {
                var collection = UriFactory.CreateDocumentCollectionUri(_dbConfig.DatabaseId, _collectionId)
            }
        }

        private DocumentClient GetClient()
        {
            return new DocumentClient(_dbConfig.EndpointUri, _dbConfig.AuthorizationKey);
        }
    }

    public class DocumentClientConfiguration
    {
        public Uri EndpointUri { get; set; }
        public string DatabaseId { get; set; }
        public string AuthorizationKey { get; set; }
        public DocumentClientConfiguration(string endpointUri, string databaseId, string authorizationKey)
        {
            EndpointUri = new Uri(endpointUri);
            DatabaseId = databaseId;
            AuthorizationKey = authorizationKey;
        }
    }
}
