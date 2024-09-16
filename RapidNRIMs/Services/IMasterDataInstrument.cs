using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public interface IMasterDataInstrument
    {
        Task<List<TModel>> PutInstrumentMasterDataAsync<TModel>(string key, TModel model);
        Task<List<TModel>> GetAllInstrumentMasterDataAsync<TModel>(string key);
        Task<List<TModel>> PostInstrumentMasterDataAsync<TModel>(string key, TModel model);
        Task<List<TModel>> GetInstrumentMasterDataAsyncByID<TModel>(string key, int? id);
    }
}
