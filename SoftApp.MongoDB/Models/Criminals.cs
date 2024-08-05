using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SoftApp.MongoDB.Models
{
    public class Criminals
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // Sql'deki UUID gibi bir alana eş değer.
        public string Id { get; set; }
        public int IdCriminals{ get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string[] GorselURL { get; set; }
        public string IlkGorselURL { get; set; }
        public string TOrgutAdi { get; set; } 
        public string TKategoriAdi { get; set; }
    }
}
