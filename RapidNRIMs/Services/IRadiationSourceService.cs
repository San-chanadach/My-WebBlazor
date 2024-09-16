using RapidNRIMs.Model.Radiations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidNRIMs.Services
{
    public interface IRadiationSourceService
    {
         Task <List<RadiationSource>> GetRadiationSources();
         Task <List<RadiationSource>> GetRadiationSourceById(int id);
    }
}