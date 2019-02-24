using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace newApp.Models
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string AuthorName { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Books")]
        public BsonObjectId[] Books { get; set;}
    }
}