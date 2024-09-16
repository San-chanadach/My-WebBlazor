using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public interface IMasterDataRecord
    {
        Task<List<TModel>> GetDistrictBYID<TModel>(string key, int? id);
        Task<List<TModel>> GetEventResult<TModel>(string key, int id);
        Task<List<TModel>> PostEventTypeMasterDataAsync<TModel>(string key, TModel model);
    }
}
