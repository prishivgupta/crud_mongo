using MongoDB.Driver;
using crud_mongo.Models;
using Microsoft.Extensions.Options;

namespace crud_mongo.Services
{
    public class ProductServices
    {
        private readonly IMongoCollection<ProductModel> _productsCollection;

        public ProductServices(IOptions<StoreSettings> storeSettings)
        {
            MongoClient client = new MongoClient(storeSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(storeSettings.Value.DatabaseName);
            _productsCollection = database.GetCollection<ProductModel>(storeSettings.Value.CollectionName);
        }

        public async Task<List<ProductModel>> GetAsync() => await _productsCollection.Find(_ => true).ToListAsync();

        public async Task<ProductModel?> GetAsync(string id) => await _productsCollection.Find(x => x.id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(ProductModel newProduct) => await _productsCollection.InsertOneAsync(newProduct);
        
        public async Task UpdateAsync(string id, ProductModel updatedProduct) =>  await _productsCollection.ReplaceOneAsync(x => x.id == id, updatedProduct);

        public async Task RemoveAsync(string id) => await _productsCollection.DeleteOneAsync(x => x.id == id);
    }
}
