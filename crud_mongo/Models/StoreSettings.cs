namespace crud_mongo.Models
{
    public class StoreSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!; 
    }
}
