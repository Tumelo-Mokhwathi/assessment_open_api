using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace open_api.Services.Interface
{
    public interface IService
    {
        Task<List<string>> GetCategoriesAsync();
        Task<List<Models.Results>> GetPeopleAsync();
        Task<List<Models.Result>> SearchAsync(string jokesQuery, string queryPeople);
    }
}
