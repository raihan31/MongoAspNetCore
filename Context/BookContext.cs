using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using newApp.Context;
using newApp.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace newApp.Context {
    public class BookContext : IBookContext
    {
        private readonly IMongoDatabase _db;
        public BookContext(IConfiguration config) {
           var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
           _db = client.GetDatabase("BookStoreDb");
        }
        
        public IMongoCollection<Author> Authors => _db.GetCollection<Author>("Authors");
        public IMongoCollection<Book> Books => _db.GetCollection<Book>("Books");
        
    }

}