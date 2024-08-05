using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SoftApp.MongoDB.MongoDB;

namespace SoftApp_MongoDB.Models
{
    public class User 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // Sql'deki UUID gibi bir alana eş değer.
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }

    }
}
