using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model.Cores;
using RapidNRIMs.Model.Radiations;

namespace RapidNRIMs.Services
{
    public interface IRadiationSourceTypeService
    {
         Task <List<RadiationSourceType>> GetRadiationSourceTypes();
    }
}