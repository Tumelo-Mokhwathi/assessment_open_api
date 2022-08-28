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
    public class SwapiController : ControllerBase
    {
        private const string EndpointPrefix = General.apiPrefixName + "swapi.";

        private readonly IService _service;

        public SwapiController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("people")]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(
                HttpStatusCode.OK,
                await _service.GetPeopleAsync().ConfigureAwait(false),
                $"{EndpointPrefix}getpeople");
    }
}
