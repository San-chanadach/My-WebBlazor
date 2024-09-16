using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public interface IMasterDataInventory
    {
        Task<TModel> PutInventoryMasterDataAsync<TModel>(string key, TModel model);
        Task<List<TModel>> GetAllInventoryMasterDataAsync<TModel>(string key);
        Task<List<TModel>> GetInventoryStockMasterDataAsyncByID<TModel>(string key, int id);
        Task<List<TModel>> PostInventoryMasterDataAsync<TModel>(string key, TModel model);
    }
}
