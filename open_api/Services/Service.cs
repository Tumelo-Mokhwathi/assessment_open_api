using open_api.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using open_api.Configurations;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace open_api.Services
{
    public class Service : IService
    {
        private readonly BaseUrl _baseUrl;

        HttpClient client = new HttpClient();

        public Service(IOptions<BaseUrl> baseUrl)
        {
            _baseUrl = baseUrl.Value;
        }
        public async Task<List<string>> GetCategoriesAsync()
        {
            var response = await GetResponseAsync($"{_baseUrl.CategoriesBaseUrl}categories/");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public async Task<List<Models.Results>> GetPeopleAsync()
        {
            var response = await GetResponseAsync(_baseUrl.SwapiBaseUrl);

            return JsonConvert.DeserializeObject<Models.Response>(response).Results.Select(r => new Models.Results
            {
                Name = r.Name,
                Height = r.Height,
                Mass = r.Mass,
                HairColor = r.HairColor,
                SkinColor = r.SkinColor,
                EyeColor = r.EyeColor,
                BirthYear = r.BirthYear,
                Gender = r.Gender,
                HomeWorld = r.HomeWorld,
                Films = r.Films,
                Species = r.Species,
                Vehicles = r.Vehicles,
                Starships = r.Starships,
                Created = r.Created,
                Edited = r.Edited,
                Url = r.Url
            })
            .ToList();
        }

        public async Task<List<Models.Result>> SearchAsync(string jokesQuery, string queryPeople)
        {
            var response = await GetResponseAsync($"{_baseUrl.CategoriesBaseUrl}search?query={jokesQuery}&&{_baseUrl.SwapiBaseUrl}?search={queryPeople}");

            return JsonConvert.DeserializeObject<Models.SearchResponse>(response).Result.Select(r => new Models.Result
            {
                Id = r.Id,
                Categories = r.Categories,
                CreatedAt = r.CreatedAt,
                Icon_Url = r.Icon_Url,
                UpdatedAt = r.UpdatedAt,
                Url = r.Url,
                Value = r.Value
            })
            .ToList();
        }

        private async Task<string> GetResponseAsync(string baseUrl)
        {
            client.DefaultRequestHeaders.Add("Accept", "*/*");

            var response = await client.GetStringAsync(baseUrl).ConfigureAwait(false);

            return response;
        }
    }
}
