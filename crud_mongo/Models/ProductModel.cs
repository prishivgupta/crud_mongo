using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace crud_mongo.Models
{
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        [BsonElement("productName")]
        public string productName { get; set; } = null!;
        public string productDescription { get; set; } = null!;
        public int productPrice { get; set; }
        public string category { get; set; } = null!;

    }
}
