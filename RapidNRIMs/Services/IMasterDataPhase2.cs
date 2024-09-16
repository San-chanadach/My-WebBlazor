using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public interface IMasterDataPhase2
    {
        Task<List<TModel>> GetMasterDataAsync<TModel>(string key);
        Task<List<TModel>> GetAllActiveMasterDataAsync<TModel>(string key);
        Task<TModel> GetMasterDataAsyncByID<TModel>(string key, int? id);
        Task<TModel> PostMasterDataAsync<TModel>(string key, TModel model);
        Task<TModel> PutMasterDataAsync<TModel>(string key, TModel model, int? id);
        Task<TModel> DeleteMasterDataAsync<TModel>(string key, int? id);
    }
}
