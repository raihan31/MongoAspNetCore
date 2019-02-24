using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using newApp.Models;

namespace newApp.Context {
    public interface IBookContext
    {
        IMongoCollection<Author> Authors { get; }
        IMongoCollection<Book> Books { get; }
        
    }

}