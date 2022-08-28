using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using open_api.Constants;
using open_api.Response;
using open_api.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace open_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private const string EndpointPrefix = General.apiPrefixName + "search.";

        private readonly IService _service;

        public SearchController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string jokesQuery, string queryPeople) =>
            ActionResponse.Success(
                HttpStatusCode.OK,
                await _service.SearchAsync(jokesQuery, queryPeople).ConfigureAwait(false),
                $"{EndpointPrefix}getsearchresult");

    }
}
