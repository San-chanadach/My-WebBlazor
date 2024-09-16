using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapidNRIMs.Model;
using RapidNRIMs.Model.Securitys;

namespace RapidNRIMs.Services
{
    public interface ILanguageService
    {
        Task <List<LanguageModels>> GetLanguageModels();    
    }
}